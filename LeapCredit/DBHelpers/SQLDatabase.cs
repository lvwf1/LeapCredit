using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Configuration;
using System.Web.Mvc;
using SlarkInc.Models;


namespace SlarkInc.DBHelpers 
{
    public class SQLDatabase 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static DataSet Select()
        {
            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbDataAdapter myCommandd = new OleDbDataAdapter(
                    "select [storage].[ID],[storage].[Name],[storage].[Size],[storage].[Type],[container].[CDNUri],[storage].[IsPublished],[container].[ContainerName] from [storage],[container] where [storage].[ContainerID] = [container].[ID]", objConnection);
                DataSet ds = new DataSet();
                myCommandd.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="ID"></param>
        public static void Delete(string ID)
        {
            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbCommand myCommandd = new OleDbCommand("delete from [storage] where id = " + ID , objConnection);
                myCommandd.ExecuteNonQuery();
            }
        }

        public static void DeleteContainer(string containerName)
        {
            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                // First delete the container's storage items (if any)
                string sql = "DELETE from [storage] where " +
                    "[storage].[ContainerID] IN (SELECT [ID] from [container] where [container].[ContainerName] = '" + containerName + "')";                
                using (OleDbCommand command = new OleDbCommand(sql, objConnection))
                {
                    command.ExecuteNonQuery();
                }

                // Now delete the container itself
                sql = "DELETE FROM [container] where [container].[ContainerName] = '" + containerName + "'";
                using (OleDbCommand command = new OleDbCommand(sql, objConnection))
                {
                    command.ExecuteNonQuery();
                }                
            }

        }

        public static void DeleteStorageItem(string containerName, string storageItemName)
        {
            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbCommand command = new OleDbCommand("DELETE from [storage] where [storage].[Name]='" + storageItemName +
                    "' and [storage].[ContainerID] IN (SELECT [ID] from [container] where [container].[ContainerName] = '" + containerName + "')",
                    objConnection);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="name"></param>
        public static void CreateContainer(string name)
        {
            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbCommand myCommandd = new OleDbCommand("insert into [container](ContainerName) values ( '" + name+"')", objConnection);
                myCommandd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int SelectContainerID(string name)
        {
            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbCommand command = new OleDbCommand("select [container].[ID],[container].[ContainerName] from [container] where ContainerName='"+name+"'", objConnection);

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToInt32(reader[0].ToString());
                }
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="containerID"></param>
        /// <returns></returns>
        public static int ContainerIncludeFile(string name,int containerID)
        {
            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbCommand command = new OleDbCommand("select * from [storage] where [storage].[Name]='" + name + "' and [storage].[ContainerID]= " + containerID, objConnection);

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToInt32(reader[0].ToString());
                }
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllContainerNames()
        {
            List<string> containerList = new List<string>();

            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbDataAdapter myCommandd = new OleDbDataAdapter("select [container].[ContainerName] from [container]", objConnection);
                DataSet ds = new DataSet();
                myCommandd.Fill(ds);

                foreach (DataRow dt in ds.Tables[0].Rows)
                {
                    string containerName = dt["ContainerName"].ToString();
                    containerList.Add(containerName);
                }
            }

            return containerList;
        }

        public static List<JC_Model> GetAllJC_Model_byIDLastName(string activation_code,string lastName)
        {
            List<JC_Model> file_to_DMS_List = new List<JC_Model>();

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("ConStr"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
					 cmd.CommandText = "sp_select_JC_model_by_activatiocodeLastName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@activation_code ", SqlDbType.NVarChar);
                cmd.Parameters["@activation_code "].Value = activation_code;
					 cmd.Parameters.Add("@last_name", SqlDbType.NVarChar);
					 cmd.Parameters["@last_name"].Value = lastName;
                               
                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JC_Model dm = new JC_Model();
                    dm.FirstName = reader["FirstName"].ToString();
                    dm.LastName = reader["LastName"].ToString();
                    dm.Phone = reader["Phone"].ToString();
                    dm.Company = reader["Company"].ToString();
                    dm.Activation_code = activation_code;
                    dm.Address = reader["Address"].ToString();
                    dm.City = reader["City"].ToString();
                    dm.State = reader["State"].ToString();
                    dm.Zip5 = reader["Zip5"].ToString();
                    dm.Zipfour = reader["Zipfour"].ToString();
                    dm.TitleCode = reader["TitleCode"].ToString();
                    dm.TitleCodeDescription = reader["TitleCodeDescription"].ToString();
						  dm.camp_id = reader["camp_id"].ToString();

                    file_to_DMS_List.Add(dm);
                }
            }

            return file_to_DMS_List;
        }

        public static List<JC_Model> GetAllJC_Model_byActivationCode(string activation_code, string lastName)
        {
            List<JC_Model> file_to_DMS_List = new List<JC_Model>();

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("ConStr"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_select_JC_model_by_activatiocode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@activation_code ", SqlDbType.NVarChar);
                cmd.Parameters["@activation_code "].Value = activation_code;
             

                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JC_Model dm = new JC_Model();
                    dm.FirstName = reader["FirstName"].ToString();
                    dm.LastName = reader["LastName"].ToString();
                    dm.Phone = reader["Phone"].ToString();
                    dm.Company = reader["Company"].ToString();
                    dm.Activation_code = activation_code;
                    dm.Address = reader["Address"].ToString();
                    dm.City = reader["City"].ToString();
                    dm.State = reader["State"].ToString();
                    dm.Zip5 = reader["Zip5"].ToString();
                    dm.Zipfour = reader["Zipfour"].ToString();
                    dm.TitleCode = reader["TitleCode"].ToString();
                    dm.TitleCodeDescription = reader["TitleCodeDescription"].ToString();
                    dm.camp_id = reader["camp_id"].ToString();
                    dm.DebtAmount = reader["DebtAmount"].ToString();

                    file_to_DMS_List.Add(dm);
                }
            }

            return file_to_DMS_List;
        }

        public static List<LeapCreditApplication> GetAllLeapCreditApplication_bySSN(string ssn)
        {
            List<LeapCreditApplication> file_to_DMS_List = new List<LeapCreditApplication>();

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("LeapCreditConnectionString"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_select_LeapCreditApplication_bySSN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ssn ", SqlDbType.NVarChar);
                cmd.Parameters["@ssn "].Value = ssn;


                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LeapCreditApplication dm = new LeapCreditApplication();
                    dm.First_Name = reader["Firs_tName"].ToString();
                    
                    file_to_DMS_List.Add(dm);
                }
            }

            return file_to_DMS_List;
        }

        public static void UpdateDateTime_byCode(string activation_code)
        {
          
            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("ConStr"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_update_FirstEnterCodeTime";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@activation_code ", SqlDbType.NVarChar);
                cmd.Parameters["@activation_code "].Value = activation_code;
                cmd.Parameters.Add("@enterCodeTime", SqlDbType.NVarChar);
                cmd.Parameters["@enterCodeTime"].Value = System.DateTime.Now.ToString();

                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                }
            }

        }

        public static void InsertEmptyOrWrongCodeLog(string activation_code)
        {

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("ConStr"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_Insert_EmptyOrWrongCode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@activation_code ", SqlDbType.NVarChar);
                cmd.Parameters["@activation_code "].Value = activation_code == null ? "" : activation_code;
                cmd.Parameters.Add("@enterCodeTime", SqlDbType.NVarChar);
                cmd.Parameters["@enterCodeTime"].Value = System.DateTime.Now.ToString();

                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
            }

        }

        public static void InsertMMApplyModel(MM_ApplyModel applyModel)
        {

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("ConStr"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_Insert_ApplyModel";//@FirstName,@LastName,@Email,@Phone,@activation_code,@ApplyFromIPAddress,@ApplyTime
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                cmd.Parameters["@FirstName"].Value = applyModel.FirstName == null ? "" : applyModel.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                cmd.Parameters["@LastName"].Value = applyModel.LastName == null ? "" : applyModel.LastName;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = applyModel.Email == null ? "" : applyModel.Email;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                cmd.Parameters["@Phone"].Value = applyModel.Phone == null ? "" : applyModel.Phone;
                cmd.Parameters.Add("@activation_code", SqlDbType.NVarChar);
                cmd.Parameters["@activation_code"].Value = applyModel.Activation_code == null ? "" : applyModel.Activation_code;
                cmd.Parameters.Add("@SubmitFromIPAddress", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitFromIPAddress"].Value = applyModel.SubmitFromIPAddress == null ? "" : applyModel.SubmitFromIPAddress;
                cmd.Parameters.Add("@SubmitFromBtn", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitFromBtn"].Value = applyModel.SubmitFromBtn == null ? "" : applyModel.SubmitFromBtn;

                cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                cmd.Parameters["@Address"].Value = applyModel.Address == null ? "" : applyModel.Address;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar);
                cmd.Parameters["@City"].Value = applyModel.City == null ? "" : applyModel.City;
                cmd.Parameters.Add("@Company", SqlDbType.NVarChar);
                cmd.Parameters["@Company"].Value = applyModel.Company == null ? "" : applyModel.Company;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar);
                cmd.Parameters["@State"].Value = applyModel.State == null ? "" : applyModel.State;
                cmd.Parameters.Add("@StateDescription", SqlDbType.NVarChar);
                cmd.Parameters["@StateDescription"].Value = applyModel.StateDescription == null ? "" : applyModel.StateDescription;
                cmd.Parameters.Add("@TitleCode", SqlDbType.NVarChar);
                cmd.Parameters["@TitleCode"].Value = applyModel.TitleCode == null ? "" : applyModel.TitleCode;
                cmd.Parameters.Add("@TitleCodeDescription", SqlDbType.NVarChar);
                cmd.Parameters["@TitleCodeDescription"].Value = applyModel.TitleCodeDescription == null ? "" : applyModel.TitleCodeDescription;
                cmd.Parameters.Add("@Zip5", SqlDbType.NVarChar);
                cmd.Parameters["@Zip5"].Value = applyModel.Zip5 == null ? "" : applyModel.Zip5;
                cmd.Parameters.Add("@Zipfour", SqlDbType.NVarChar);
                cmd.Parameters["@Zipfour"].Value = applyModel.Zipfour == null ? "" : applyModel.Zipfour;
					 cmd.Parameters.Add("@camp_id", SqlDbType.NVarChar);
					 cmd.Parameters["@camp_id"].Value = applyModel.camp_id == null ? "" : applyModel.camp_id;
                cmd.Parameters.Add("@DebtAmount", SqlDbType.NVarChar);
                cmd.Parameters["@DebtAmount"].Value = applyModel.DebtAmount == null ? "" : applyModel.DebtAmount;

                cmd.Parameters.Add("@SubmitTime", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitTime"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                }
                catch { 
                    
                }
            }

        }

        public static void InsertStep1Insert_LeapCreditApplication(LeapCreditApplication applyModel)
        {

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("LeapCreditConnectionString"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_Step1Insert_LeapCreditApplication";//@FirstName,@LastName,@Email,@Phone,@activation_code,@ApplyFromIPAddress,@ApplyTime
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@First_Name", SqlDbType.NVarChar);
                cmd.Parameters["@First_Name"].Value = applyModel.First_Name == null ? "" : applyModel.First_Name;
                cmd.Parameters.Add("@Last_Name", SqlDbType.NVarChar);
                cmd.Parameters["@Last_Name"].Value = applyModel.Last_Name == null ? "" : applyModel.Last_Name;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = applyModel.Email == null ? "" : applyModel.Email;
                cmd.Parameters.Add("@Loan_Amount", SqlDbType.NVarChar);
                cmd.Parameters["@Loan_Amount"].Value = applyModel.Loan_Amount == null ? "" : applyModel.Loan_Amount;
                cmd.Parameters.Add("@Paycheck_Period", SqlDbType.NVarChar);
                cmd.Parameters["@Paycheck_Period"].Value = applyModel.Paycheck_Period == null ? "" : applyModel.Paycheck_Period;
                cmd.Parameters.Add("@Gross_Income_per_Paycheck", SqlDbType.NVarChar);
                cmd.Parameters["@Gross_Income_per_Paycheck"].Value = applyModel.Gross_Income_per_Paycheck == null ? "" : applyModel.Gross_Income_per_Paycheck;
               
                cmd.Parameters.Add("@SubmitFromBtn", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitFromBtn"].Value = applyModel.SubmitFromBtn == null ? "" : applyModel.SubmitFromBtn;
                cmd.Parameters.Add("@SubmitTime", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitTime"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                }
                catch(Exception ex)
                {

                }
            }

        }

        public static void InsertStep2_LeapCreditApplication(LeapCreditApplication applyModel)
        {

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("LeapCreditConnectionString"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_Step2Insert_LeapCreditApplication";//@FirstName,@LastName,@Email,@Phone,@activation_code,@ApplyFromIPAddress,@ApplyTime
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@First_Name", SqlDbType.NVarChar);
                cmd.Parameters["@First_Name"].Value = applyModel.First_Name == null ? "" : applyModel.First_Name;
                cmd.Parameters.Add("@Last_Name", SqlDbType.NVarChar);
                cmd.Parameters["@Last_Name"].Value = applyModel.Last_Name == null ? "" : applyModel.Last_Name;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = applyModel.Email == null ? "" : applyModel.Email;
                cmd.Parameters.Add("@Loan_Amount", SqlDbType.NVarChar);
                cmd.Parameters["@Loan_Amount"].Value = applyModel.Loan_Amount == null ? "" : applyModel.Loan_Amount;
                cmd.Parameters.Add("@Paycheck_Period", SqlDbType.NVarChar);
                cmd.Parameters["@Paycheck_Period"].Value = applyModel.Paycheck_Period == null ? "" : applyModel.Paycheck_Period;
                cmd.Parameters.Add("@Gross_Income_per_Paycheck", SqlDbType.NVarChar);
                cmd.Parameters["@Gross_Income_per_Paycheck"].Value = applyModel.Gross_Income_per_Paycheck == null ? "" : applyModel.Gross_Income_per_Paycheck;

                cmd.Parameters.Add("@ck_ACH_Authorization", SqlDbType.NVarChar);
                cmd.Parameters["@ck_ACH_Authorization"].Value = applyModel.ck_ACH_Authorization == null ? "" : applyModel.ck_ACH_Authorization.ToString();
                cmd.Parameters.Add("@Mobile_Number1", SqlDbType.NVarChar);
                cmd.Parameters["@Mobile_Number1"].Value = applyModel.Mobile_Number1 == null ? "" : applyModel.Mobile_Number1;
                cmd.Parameters.Add("@Mobile_Number2", SqlDbType.NVarChar);
                cmd.Parameters["@Mobile_Number2"].Value = applyModel.Mobile_Number2 == null ? "" : applyModel.Mobile_Number2;
                cmd.Parameters.Add("@Mobile_Number3", SqlDbType.NVarChar);
                cmd.Parameters["@Mobile_Number3"].Value = applyModel.Mobile_Number3 == null ? "" : applyModel.Mobile_Number3;
                cmd.Parameters.Add("@Secondary_Phone_Number1", SqlDbType.NVarChar);
                cmd.Parameters["@Secondary_Phone_Number1"].Value = applyModel.Secondary_Phone_Number1 == null ? "" : applyModel.Secondary_Phone_Number1;
                cmd.Parameters.Add("@Secondary_Phone_Number2", SqlDbType.NVarChar);
                cmd.Parameters["@Secondary_Phone_Number2"].Value = applyModel.Secondary_Phone_Number2 == null ? "" : applyModel.Secondary_Phone_Number2;
                cmd.Parameters.Add("@Secondary_Phone_Number3", SqlDbType.NVarChar);
                cmd.Parameters["@Secondary_Phone_Number3"].Value = applyModel.Secondary_Phone_Number3 == null ? "" : applyModel.Secondary_Phone_Number3;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                cmd.Parameters["@Address"].Value = applyModel.Address == null ? "" : applyModel.Address;
                cmd.Parameters.Add("@Address2", SqlDbType.NVarChar);
                cmd.Parameters["@Address2"].Value = applyModel.Address2 == null ? "" : applyModel.Address2;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar);
                cmd.Parameters["@City"].Value = applyModel.City == null ? "" : applyModel.City;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar);
                cmd.Parameters["@State"].Value = applyModel.State == null ? "" : applyModel.State;
                cmd.Parameters.Add("@Zip_Code", SqlDbType.NVarChar);
                cmd.Parameters["@Zip_Code"].Value = applyModel.Zip_Code == null ? "" : applyModel.Zip_Code;
                cmd.Parameters.Add("@Date_of_Birth", SqlDbType.NVarChar);
                cmd.Parameters["@Date_of_Birth"].Value = applyModel.Date_of_Birth == null ? "" : applyModel.Date_of_Birth;
                cmd.Parameters.Add("@Current_Military", SqlDbType.NVarChar);
                cmd.Parameters["@Current_Military"].Value = applyModel.Current_Military == null ? "" : applyModel.Current_Military.ToString();


                cmd.Parameters.Add("@SubmitFromBtn", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitFromBtn"].Value = applyModel.SubmitFromBtn == null ? "" : applyModel.SubmitFromBtn;
                cmd.Parameters.Add("@SubmitTime", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitTime"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {

                }
            }

        }


        public static void InsertStep3_LeapCreditApplication(LeapCreditApplication applyModel)
        {

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("LeapCreditConnectionString"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_Step3Insert_LeapCreditApplication";//@FirstName,@LastName,@Email,@Phone,@activation_code,@ApplyFromIPAddress,@ApplyTime
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@First_Name", SqlDbType.NVarChar);
                cmd.Parameters["@First_Name"].Value = applyModel.First_Name == null ? "" : applyModel.First_Name;
                cmd.Parameters.Add("@Last_Name", SqlDbType.NVarChar);
                cmd.Parameters["@Last_Name"].Value = applyModel.Last_Name == null ? "" : applyModel.Last_Name;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = applyModel.Email == null ? "" : applyModel.Email;
                cmd.Parameters.Add("@Loan_Amount", SqlDbType.NVarChar);
                cmd.Parameters["@Loan_Amount"].Value = applyModel.Loan_Amount == null ? "" : applyModel.Loan_Amount;
                cmd.Parameters.Add("@Paycheck_Period", SqlDbType.NVarChar);
                cmd.Parameters["@Paycheck_Period"].Value = applyModel.Paycheck_Period == null ? "" : applyModel.Paycheck_Period;
                cmd.Parameters.Add("@Gross_Income_per_Paycheck", SqlDbType.NVarChar);
                cmd.Parameters["@Gross_Income_per_Paycheck"].Value = applyModel.Gross_Income_per_Paycheck == null ? "" : applyModel.Gross_Income_per_Paycheck;

                cmd.Parameters.Add("@ck_ACH_Authorization", SqlDbType.NVarChar);
                cmd.Parameters["@ck_ACH_Authorization"].Value = applyModel.ck_ACH_Authorization == null ? "" : applyModel.ck_ACH_Authorization.ToString();
                cmd.Parameters.Add("@Mobile_Number1", SqlDbType.NVarChar);
                cmd.Parameters["@Mobile_Number1"].Value = applyModel.Mobile_Number1 == null ? "" : applyModel.Mobile_Number1;
                cmd.Parameters.Add("@Mobile_Number2", SqlDbType.NVarChar);
                cmd.Parameters["@Mobile_Number2"].Value = applyModel.Mobile_Number2 == null ? "" : applyModel.Mobile_Number2;
                cmd.Parameters.Add("@Mobile_Number3", SqlDbType.NVarChar);
                cmd.Parameters["@Mobile_Number3"].Value = applyModel.Mobile_Number3 == null ? "" : applyModel.Mobile_Number3;
                cmd.Parameters.Add("@Secondary_Phone_Number1", SqlDbType.NVarChar);
                cmd.Parameters["@Secondary_Phone_Number1"].Value = applyModel.Secondary_Phone_Number1 == null ? "" : applyModel.Secondary_Phone_Number1;
                cmd.Parameters.Add("@Secondary_Phone_Number2", SqlDbType.NVarChar);
                cmd.Parameters["@Secondary_Phone_Number2"].Value = applyModel.Secondary_Phone_Number2 == null ? "" : applyModel.Secondary_Phone_Number2;
                cmd.Parameters.Add("@Secondary_Phone_Number3", SqlDbType.NVarChar);
                cmd.Parameters["@Secondary_Phone_Number3"].Value = applyModel.Secondary_Phone_Number3 == null ? "" : applyModel.Secondary_Phone_Number3;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                cmd.Parameters["@Address"].Value = applyModel.Address == null ? "" : applyModel.Address;
                cmd.Parameters.Add("@Address2", SqlDbType.NVarChar);
                cmd.Parameters["@Address2"].Value = applyModel.Address2 == null ? "" : applyModel.Address2;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar);
                cmd.Parameters["@City"].Value = applyModel.City == null ? "" : applyModel.City;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar);
                cmd.Parameters["@State"].Value = applyModel.State == null ? "" : applyModel.State;
                cmd.Parameters.Add("@Zip_Code", SqlDbType.NVarChar);
                cmd.Parameters["@Zip_Code"].Value = applyModel.Zip_Code == null ? "" : applyModel.Zip_Code;
                cmd.Parameters.Add("@Date_of_Birth", SqlDbType.NVarChar);
                cmd.Parameters["@Date_of_Birth"].Value = applyModel.Date_of_Birth == null ? "" : applyModel.Date_of_Birth;
                cmd.Parameters.Add("@Current_Military", SqlDbType.NVarChar);
                cmd.Parameters["@Current_Military"].Value = applyModel.Current_Military == null ? "" : applyModel.Current_Military.ToString();

                cmd.Parameters.Add("@Drivers_License_NO", SqlDbType.NVarChar);
                cmd.Parameters["@Drivers_License_NO"].Value = applyModel.Drivers_License_NO == null ? "" : applyModel.Drivers_License_NO.ToString();
                cmd.Parameters.Add("@SSN1", SqlDbType.NVarChar);
                cmd.Parameters["@SSN1"].Value = applyModel.SSN1 == null ? "" : applyModel.SSN1.ToString();
                cmd.Parameters.Add("@SSN2", SqlDbType.NVarChar);
                cmd.Parameters["@SSN2"].Value = applyModel.SSN2 == null ? "" : applyModel.SSN2.ToString();
                cmd.Parameters.Add("@SSN3", SqlDbType.NVarChar);
                cmd.Parameters["@SSN3"].Value = applyModel.SSN3 == null ? "" : applyModel.SSN3.ToString();
                cmd.Parameters.Add("@Job_Title", SqlDbType.NVarChar);
                cmd.Parameters["@Job_Title"].Value = applyModel.Job_Title == null ? "" : applyModel.Job_Title.ToString();
                cmd.Parameters.Add("@Employer", SqlDbType.NVarChar);
                cmd.Parameters["@Employer"].Value = applyModel.Employer == null ? "" : applyModel.Employer.ToString();
                cmd.Parameters.Add("@Time_Employed_year", SqlDbType.NVarChar);
                cmd.Parameters["@Time_Employed_year"].Value = applyModel.Time_Employed_year == null ? "" : applyModel.Time_Employed_year.ToString();
                cmd.Parameters.Add("@Time_Employed_month", SqlDbType.NVarChar);
                cmd.Parameters["@Time_Employed_month"].Value = applyModel.Time_Employed_month == null ? "" : applyModel.Time_Employed_month.ToString();
                cmd.Parameters.Add("@Supervisor_Phone_Number1", SqlDbType.NVarChar);
                cmd.Parameters["@Supervisor_Phone_Number1"].Value = applyModel.Supervisor_Phone_Number1 == null ? "" : applyModel.Supervisor_Phone_Number1.ToString();
                cmd.Parameters.Add("@Supervisor_Phone_Number2", SqlDbType.NVarChar);
                cmd.Parameters["@Supervisor_Phone_Number2"].Value = applyModel.Supervisor_Phone_Number2 == null ? "" : applyModel.Supervisor_Phone_Number2.ToString();
                cmd.Parameters.Add("@Supervisor_Phone_Number3", SqlDbType.NVarChar);
                cmd.Parameters["@Supervisor_Phone_Number3"].Value = applyModel.Supervisor_Phone_Number3 == null ? "" : applyModel.Supervisor_Phone_Number3.ToString();
                cmd.Parameters.Add("@Employer_Addresss", SqlDbType.NVarChar);
                cmd.Parameters["@Employer_Addresss"].Value = applyModel.Employer_Addresss == null ? "" : applyModel.Employer_Addresss.ToString();
                cmd.Parameters.Add("@Employer_City", SqlDbType.NVarChar);
                cmd.Parameters["@Employer_City"].Value = applyModel.Employer_City == null ? "" : applyModel.Employer_City.ToString();
                cmd.Parameters.Add("@Employer_State", SqlDbType.NVarChar);
                cmd.Parameters["@Employer_State"].Value = applyModel.Employer_State == null ? "" : applyModel.Employer_State.ToString();
                cmd.Parameters.Add("@Employer_Zip_Code", SqlDbType.NVarChar);
                cmd.Parameters["@Employer_Zip_Code"].Value = applyModel.Employer_Zip_Code == null ? "" : applyModel.Employer_Zip_Code.ToString();
                cmd.Parameters.Add("@Purpose_for_Loan", SqlDbType.NVarChar);
                cmd.Parameters["@Purpose_for_Loan"].Value = applyModel.Purpose_for_Loan == null ? "" : applyModel.Purpose_for_Loan.ToString();
                cmd.Parameters.Add("@How_did_you_hear_about_LeapCredit", SqlDbType.NVarChar);
                cmd.Parameters["@How_did_you_hear_about_LeapCredit"].Value = applyModel.How_did_you_hear_about_LeapCredit == null ? "" : applyModel.How_did_you_hear_about_LeapCredit.ToString();



                cmd.Parameters.Add("@SubmitFromBtn", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitFromBtn"].Value = applyModel.SubmitFromBtn == null ? "" : applyModel.SubmitFromBtn;
                cmd.Parameters.Add("@SubmitTime", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitTime"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {

                }
            }

        }
        public static void UpdateMMApplyModelByActivationCode(MM_ApplyModel applyModel)
        {

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("ConStr"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.CommandText = "sp_Update_ApplyModelByActivationCode";//@FirstName,@LastName,@Email,@Phone,@activation_code,@ApplyFromIPAddress,@ApplyTime
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                cmd.Parameters["@FirstName"].Value = applyModel.FirstName == null ? "" : applyModel.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                cmd.Parameters["@LastName"].Value = applyModel.LastName == null ? "" : applyModel.LastName;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = applyModel.Email == null ? "" : applyModel.Email;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                cmd.Parameters["@Phone"].Value = applyModel.Phone == null ? "" : applyModel.Phone;
                cmd.Parameters.Add("@activation_code", SqlDbType.NVarChar);
                cmd.Parameters["@activation_code"].Value = applyModel.Activation_code == null ? "" : applyModel.Activation_code;
                cmd.Parameters.Add("@SubmitFromIPAddress", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitFromIPAddress"].Value = applyModel.SubmitFromIPAddress == null ? "" : applyModel.SubmitFromIPAddress;
                cmd.Parameters.Add("@SubmitFromBtn", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitFromBtn"].Value = applyModel.SubmitFromBtn == null ? "" : applyModel.SubmitFromBtn;


                cmd.Parameters.Add("@SubmitTime", SqlDbType.NVarChar);
                cmd.Parameters["@SubmitTime"].Value = System.DateTime.Now.ToString();

                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                }
                catch
                {

                }
            }

        }

		  

		  public static bool IfExistActivationCode(string activationCode) {
			  using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("ConStr"))
			  {
				  SqlCommand cmd = new SqlCommand();
				  cmd.Connection = objConnection;
				  cmd.CommandText = "sp_Select_IfExistActivationCode";
				  cmd.CommandType = CommandType.StoredProcedure;
				  cmd.Parameters.Add("@activation_code ", SqlDbType.NVarChar);
				  cmd.Parameters["@activation_code "].Value = activationCode == null ? "" : activationCode;
				  

				  //cmd.ExecuteNonQuery();
				  //cmd.ExecuteReader();

				  SqlDataReader reader = cmd.ExecuteReader();
				  return reader.HasRows;
				  //while (reader.Read())
				  //{

				  //}
			  }
			  
		  }

        public static void ExecuteSqlTransaction(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");
                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
                    command.ExecuteNonQuery();
                    command.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
                    command.ExecuteNonQuery();
                    // Attempt to commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
            }
        }

        public static void ExecuteSqlTransactionTest()
        {
            SqlConnection mySqlConnection =  new SqlConnection("server=localhost;database=Northwind;uid=sa;pwd=sa");
            mySqlConnection.Open();
            // 创建SqlTransaction 对象并用SqlConnection对象的
            // BeginTransaction()方法开始事务
            SqlTransaction mySqlTransaction =mySqlConnection.BeginTransaction();
            // 创建保存SQL语句
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            // 将Transaction属性设置为上面所生成的SqlTransaction对象
            mySqlCommand.Transaction = mySqlTransaction;
            // 将SqlCommand对象的CommandText属性设置为第一个INSERT语句，
            // 第一个INSERT语句在Customers表中增加一行
            mySqlCommand.CommandText =
            "INSERT INTO Customers (" +
            " CustomerID, CompanyName" +
            ") VALUES (" +
            " 'Micro', 'Microsoft Corporation'" +
            ")";
            // 执行第一个INSERT语句
            Console.WriteLine("Running first INSERT statement");
            mySqlCommand.ExecuteNonQuery();
            // 将SqlCommand对象的CommandText属性设置为第二个INSERT语句，
            // 第二个INSERT语句在Orders表中增加一行
            mySqlCommand.CommandText =
            "INSERT INTO Orders (" +
            " CustomerID" +
            ") VALUES (" +
            " 'Micro'" +
            ")";
            // 执行第二个INSERT语句
            Console.WriteLine("Running second INSERT statement");
            mySqlCommand.ExecuteNonQuery();
            // 提交事务，使INSERT语句增加的两行在数据库中保存起来
            Console.WriteLine("Committing transaction");
            mySqlTransaction.Commit();
            mySqlConnection.Close();
        }
        
        public static List<string> GetStorageItems(string containerName)
        {
            containerName = containerName.Replace("'", "''");

            List<string> storageItemList = new List<string>();

            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbDataAdapter myCommand = new OleDbDataAdapter(
                    "select [storage].[Name] from [storage], [container] where [storage].ContainerID = [container].ID and [container].ContainerName = '" + @containerName + "'", objConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds);

                foreach (DataRow dt in ds.Tables[0].Rows)
                {
                    string itemName = dt["Name"].ToString();
                    storageItemList.Add(itemName);
                }
            }

            return storageItemList;
        }

        

        public static bool UploadFile(string filePath, string containerName)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerName"></param>
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerName"></param>
        public static void MakeContainerPrivate(string containerName)
        {
            string sqlContainerName = containerName.Replace("'", "''");

            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbCommand myCommandd = new OleDbCommand(
                    "update [container] set IsPublished = false, CDNUri = '' where [container].[ContainerName]='"
                    + sqlContainerName + "'", objConnection);
                myCommandd.ExecuteNonQuery();
            }
        }

        public static List<string> GetPublicContainers()
        {
            List<string> containers = new List<string>();

            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                OleDbCommand cmm = new OleDbCommand("Select ContainerName from [container] where IsPublished=TRUE", objConnection);
                OleDbDataReader reader = cmm.ExecuteReader();

                while (reader.Read())
                {
                    containers.Add(reader["ContainerName"].ToString());
                }
            }

            return containers;
        }

        public static bool GetContainerStatus(string containerName)
        {
            bool isPublished = false;
             using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
             {
                 OleDbCommand cmm = new OleDbCommand("select IsPublished from [container] where ContainerName='" + containerName + "'", objConnection);
                 OleDbDataReader reader = cmm.ExecuteReader();

                 while (reader.Read())
                 {
                     isPublished =  Convert.ToBoolean(reader[0].ToString());
                 }
             }
             return isPublished;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileRequest"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public static bool UploadFile(HttpFileCollectionBase fileRequest, string containerName)
        {
                string fileName = Path.GetFileName(fileRequest[0].FileName);
                string fileType = Path.GetExtension(fileRequest[0].FileName);
                string root = HttpContext.Current.Server.MapPath("/");
                string fileAddress = root+"\\storage\\"+fileName;

                int size = fileRequest[0].ContentLength/1024/1024;

                int containerID = SelectContainerID(containerName);
                if (containerID != -1)
                {

                    if (ContainerIncludeFile(fileName, containerID) == -1)
                    {
                        
                        fileRequest[0].SaveAs(fileAddress);

                        Create(fileName, size, fileType, false, containerID);
                        return true;
                    }
                    return false;
                }

                return false;

        }



        /// <summary>
        ///
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="size"></param>
        /// <param name="fileType"></param>
        /// <param name="isPublished"></param>
        /// <param name="ContainerID"></param>
        public static void Create(string fileName, int size, string fileType, bool isPublished,int ContainerID)
        {
            using (OleDbConnection objConnection = SQLDatabaseHelper.GetConnection())
            {
                string sql = string.Format("insert into [storage]([Name],[Size],[Type],[IsPublished],[ContainerID]) values ( '{0}',{1},'{2}',{3},{4})", fileName, size, fileType, isPublished,ContainerID);
                OleDbCommand myCommandd = new OleDbCommand(sql, objConnection);

                myCommandd.ExecuteNonQuery();
            }
        }

       
        



        public static void InsertUpdateStorageAuthToken(string authToken, string userName, string location, string createDateTime,string storageUrl)
        {

            using (SqlConnection objConnection = SQLDatabaseHelper.GetSqlConnection("UAM_version2"))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConnection;
                cmd.Parameters.Add("@userName", SqlDbType.NVarChar);
                cmd.Parameters["@userName"].Value = userName;
                cmd.Parameters.Add("@authToken", SqlDbType.NVarChar);
                cmd.Parameters["@authToken"].Value = authToken;
                cmd.Parameters.Add("@location", SqlDbType.NVarChar);
                cmd.Parameters["@location"].Value = location;
                cmd.Parameters.Add("@createTime", SqlDbType.NVarChar);
                cmd.Parameters["@createTime"].Value = createDateTime;
                cmd.Parameters.Add("@storageUrl", SqlDbType.NVarChar);
                cmd.Parameters["@storageUrl"].Value = storageUrl;

                cmd.CommandText = "Portal_CreateUpdate_StorageAuthtoken";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
               

            }
        }

       

        public static bool IsAuthTokenExpired(string createTime)
        {
            if (String.IsNullOrEmpty(createTime)) return true;
            int minutes = 1440/2;//["AuthTokenOverHours=1440"]);
            DateTime dt = DateTime.Now.ToUniversalTime();
            DateTime diskTime = Convert.ToDateTime(createTime);
            TimeSpan ts = dt - diskTime;
            double totalMinutes = (dt - diskTime).TotalMinutes;
            return totalMinutes >= minutes ? true : false;
        }
    }
}