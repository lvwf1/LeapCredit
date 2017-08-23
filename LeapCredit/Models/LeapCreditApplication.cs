using System.ComponentModel.DataAnnotations;
namespace SlarkInc.Models
{

    public class LeapCreditApplication
    {

        private string _First_Name;

        private string _Last_Name;

        private string _Email;

        private string _Loan_Amount;

        private string _Paycheck_Period;

        private string _Gross_Income_per_Paycheck;

        private bool _ck_ACH_Authorization;

        private string _Mobile_Number1;
        private string _Mobile_Number2;
        private string _Mobile_Number3;

        private string _Secondary_Phone_Number1;
        private string _Secondary_Phone_Number2;
        private string _Secondary_Phone_Number3;

        private string _Address;

        private string _Address2;

        private string _City;

        private string _State;

        private string _Zip_Code;

        private string _Date_of_Birth;

        private bool _Current_Military;

        private string _Drivers_License_NO;

        private string _SSN1;
        private string _SSN2;
        private string _SSN3;

        private string _Job_Title;

        private string _Employer;

        private string _Time_Employed_year;
        private string _Time_Employed_month;

        private string _Supervisor_Phone_Number1;
        private string _Supervisor_Phone_Number2;
        private string _Supervisor_Phone_Number3;

        private string _Employer_Addresss;

        private string _Employer_City;

        private string _Employer_State;

        private string _Employer_Zip_Code;

        private string _Purpose_for_Loan;

        private string _How_did_you_hear_about_LeapCredit;

        private string _SubmitFromBtn;

        private string _SubmitTime;

        public LeapCreditApplication()
        {
        }

        [Required]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_First_Name", DbType = "NVarChar(250)")]
        public string First_Name
        {
            get
            {
                return this._First_Name;
            }
            set
            {
                if ((this._First_Name != value))
                {
                    this._First_Name = value;
                }
            }
        }

        [Required]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Last_Name", DbType = "NVarChar(250)")]
        public string Last_Name
        {
            get
            {
                return this._Last_Name;
            }
            set
            {
                if ((this._Last_Name != value))
                {
                    this._Last_Name = value;
                }
            }
        }

        [Required]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Email", DbType = "NVarChar(250)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this._Email = value;
                }
            }
        }

        [Required]
        [Display(Name = "Loan Amount")]
        [Range(typeof(decimal), "0.00", "99999999.99", ErrorMessage = "Wrong Format")]
        [RegularExpression(@"^(([0-9]+)|([0-9]+\.[0-9]{1,2}))$", ErrorMessage = "Wrong Format")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Loan_Amount", DbType = "NVarChar(250)")]
        public string Loan_Amount
        {
            get
            {
                return this._Loan_Amount;
            }
            set
            {
                if ((this._Loan_Amount != value))
                {
                    this._Loan_Amount = value;
                }
            }
        }

        [Required]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Paycheck_Period", DbType = "NVarChar(250)")]
        public string Paycheck_Period
        {
            get
            {
                return this._Paycheck_Period;
            }
            set
            {
                if ((this._Paycheck_Period != value))
                {
                    this._Paycheck_Period = value;
                }
            }
        }

        [Required]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Gross_Income_per_Paycheck", DbType = "NVarChar(250)")]
        public string Gross_Income_per_Paycheck
        {
            get
            {
                return this._Gross_Income_per_Paycheck;
            }
            set
            {
                if ((this._Gross_Income_per_Paycheck != value))
                {
                    this._Gross_Income_per_Paycheck = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ck_ACH_Authorization", DbType = "NVarChar(250)")]
        public bool ck_ACH_Authorization
        {
            get
            {
                return this._ck_ACH_Authorization;
            }
            set
            {
                if ((this._ck_ACH_Authorization != value))
                {
                    this._ck_ACH_Authorization = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[Mobile_Number]", Storage = "_Mobile_Number_", DbType = "NVarChar(250)")]
        public string Mobile_Number1
        {
            get
            {
                return this._Mobile_Number1;
            }
            set
            {
                if ((this._Mobile_Number1 != value))
                {
                    this._Mobile_Number1 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[Mobile_Number]", Storage = "_Mobile_Number_", DbType = "NVarChar(250)")]
        public string Mobile_Number2
        {
            get
            {
                return this._Mobile_Number2;
            }
            set
            {
                if ((this._Mobile_Number2 != value))
                {
                    this._Mobile_Number2 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[Mobile_Number]", Storage = "_Mobile_Number_", DbType = "NVarChar(250)")]
        public string Mobile_Number3
        {
            get
            {
                return this._Mobile_Number3;
            }
            set
            {
                if ((this._Mobile_Number3 != value))
                {
                    this._Mobile_Number3 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Secondary_Phone_Number", DbType = "NVarChar(250)")]
        public string Secondary_Phone_Number1
        {
            get
            {
                return this._Secondary_Phone_Number1;
            }
            set
            {
                if ((this._Secondary_Phone_Number1 != value))
                {
                    this._Secondary_Phone_Number1 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Secondary_Phone_Number", DbType = "NVarChar(250)")]
        public string Secondary_Phone_Number2
        {
            get
            {
                return this._Secondary_Phone_Number2;
            }
            set
            {
                if ((this._Secondary_Phone_Number2 != value))
                {
                    this._Secondary_Phone_Number2 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Secondary_Phone_Number", DbType = "NVarChar(250)")]
        public string Secondary_Phone_Number3
        {
            get
            {
                return this._Secondary_Phone_Number3;
            }
            set
            {
                if ((this._Secondary_Phone_Number3 != value))
                {
                    this._Secondary_Phone_Number3 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Address", DbType = "NVarChar(250)")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                if ((this._Address != value))
                {
                    this._Address = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Address2", DbType = "NVarChar(250)")]
        public string Address2
        {
            get
            {
                return this._Address2;
            }
            set
            {
                if ((this._Address2 != value))
                {
                    this._Address2 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_City", DbType = "NVarChar(250)")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                if ((this._City != value))
                {
                    this._City = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_State", DbType = "NVarChar(250)")]
        public string State
        {
            get
            {
                return this._State;
            }
            set
            {
                if ((this._State != value))
                {
                    this._State = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Zip_Code", DbType = "NVarChar(250)")]
        public string Zip_Code
        {
            get
            {
                return this._Zip_Code;
            }
            set
            {
                if ((this._Zip_Code != value))
                {
                    this._Zip_Code = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Date_of_Birth", DbType = "NVarChar(250)")]
        public string Date_of_Birth
        {
            get
            {
                return this._Date_of_Birth;
            }
            set
            {
                if ((this._Date_of_Birth != value))
                {
                    this._Date_of_Birth = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Current_Military", DbType = "NVarChar(250)")]
        public bool Current_Military
        {
            get
            {
                return this._Current_Military;
            }
            set
            {
                if ((this._Current_Military != value))
                {
                    this._Current_Military = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Drivers_License_NO", DbType = "NVarChar(250)")]
        public string Drivers_License_NO
        {
            get
            {
                return this._Drivers_License_NO;
            }
            set
            {
                if ((this._Drivers_License_NO != value))
                {
                    this._Drivers_License_NO = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SSN", DbType = "NVarChar(250)")]
        public string SSN1
        {
            get
            {
                return this._SSN1;
            }
            set
            {
                if ((this._SSN1 != value))
                {
                    this._SSN1 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SSN", DbType = "NVarChar(250)")]
        public string SSN2
        {
            get
            {
                return this._SSN2;
            }
            set
            {
                if ((this._SSN2 != value))
                {
                    this._SSN2 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SSN", DbType = "NVarChar(250)")]
        public string SSN3
        {
            get
            {
                return this._SSN3;
            }
            set
            {
                if ((this._SSN3 != value))
                {
                    this._SSN3 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Job_Title", DbType = "NVarChar(250)")]
        public string Job_Title
        {
            get
            {
                return this._Job_Title;
            }
            set
            {
                if ((this._Job_Title != value))
                {
                    this._Job_Title = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer", DbType = "NVarChar(250)")]
        public string Employer
        {
            get
            {
                return this._Employer;
            }
            set
            {
                if ((this._Employer != value))
                {
                    this._Employer = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Time_Employed_year", DbType = "NVarChar(250)")]
        public string Time_Employed_year
        {
            get
            {
                return this._Time_Employed_year;
            }
            set
            {
                if ((this._Time_Employed_year != value))
                {
                    this._Time_Employed_year = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Time_Employed_month", DbType = "NVarChar(250)")]
        public string Time_Employed_month
        {
            get
            {
                return this._Time_Employed_month;
            }
            set
            {
                if ((this._Time_Employed_month != value))
                {
                    this._Time_Employed_month = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Supervisor_Phone_Number", DbType = "NVarChar(250)")]
        public string Supervisor_Phone_Number1
        {
            get
            {
                return this._Supervisor_Phone_Number1;
            }
            set
            {
                if ((this._Supervisor_Phone_Number1 != value))
                {
                    this._Supervisor_Phone_Number1 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Supervisor_Phone_Number", DbType = "NVarChar(250)")]
        public string Supervisor_Phone_Number2
        {
            get
            {
                return this._Supervisor_Phone_Number2;
            }
            set
            {
                if ((this._Supervisor_Phone_Number2 != value))
                {
                    this._Supervisor_Phone_Number2 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Supervisor_Phone_Number", DbType = "NVarChar(250)")]
        public string Supervisor_Phone_Number3
        {
            get
            {
                return this._Supervisor_Phone_Number3;
            }
            set
            {
                if ((this._Supervisor_Phone_Number3 != value))
                {
                    this._Supervisor_Phone_Number3 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer_Addresss", DbType = "NVarChar(250)")]
        public string Employer_Addresss
        {
            get
            {
                return this._Employer_Addresss;
            }
            set
            {
                if ((this._Employer_Addresss != value))
                {
                    this._Employer_Addresss = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer_City", DbType = "NVarChar(250)")]
        public string Employer_City
        {
            get
            {
                return this._Employer_City;
            }
            set
            {
                if ((this._Employer_City != value))
                {
                    this._Employer_City = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer_State", DbType = "NVarChar(250)")]
        public string Employer_State
        {
            get
            {
                return this._Employer_State;
            }
            set
            {
                if ((this._Employer_State != value))
                {
                    this._Employer_State = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer_Zip_Code", DbType = "NVarChar(250)")]
        public string Employer_Zip_Code
        {
            get
            {
                return this._Employer_Zip_Code;
            }
            set
            {
                if ((this._Employer_Zip_Code != value))
                {
                    this._Employer_Zip_Code = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Purpose_for_Loan", DbType = "NVarChar(250)")]
        public string Purpose_for_Loan
        {
            get
            {
                return this._Purpose_for_Loan;
            }
            set
            {
                if ((this._Purpose_for_Loan != value))
                {
                    this._Purpose_for_Loan = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_How_did_you_hear_about_LeapCredit", DbType = "NVarChar(250)")]
        public string How_did_you_hear_about_LeapCredit
        {
            get
            {
                return this._How_did_you_hear_about_LeapCredit;
            }
            set
            {
                if ((this._How_did_you_hear_about_LeapCredit != value))
                {
                    this._How_did_you_hear_about_LeapCredit = value;
                }
            }
        }

        public string SubmitFromBtn
        {
            get
            {
                return this._SubmitFromBtn;
            }
            set
            {
                if ((this._SubmitFromBtn != value))
                {
                    this._SubmitFromBtn = value;
                }
            }
        }
        public string SubmitTime
        {
            get
            {
                return this._SubmitTime;
            }
            set
            {
                if ((this._SubmitTime != value))
                {
                    this._SubmitTime = value;
                }
            }
        }

    }

    public class LeapCreditApplicationForm1
    {

        private string _First_Name;

        private string _Last_Name;

        private string _Email;

        private string _Loan_Amount;

        private string _Paycheck_Period;

        private string _Gross_Income_per_Paycheck;

       

        private string _SubmitFromBtn;

        private string _SubmitTime;

        public LeapCreditApplicationForm1()
        {
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_First_Name", DbType = "NVarChar(250)")]
        public string First_Name
        {
            get
            {
                return this._First_Name;
            }
            set
            {
                if ((this._First_Name != value))
                {
                    this._First_Name = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Last_Name", DbType = "NVarChar(250)")]
        public string Last_Name
        {
            get
            {
                return this._Last_Name;
            }
            set
            {
                if ((this._Last_Name != value))
                {
                    this._Last_Name = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Email", DbType = "NVarChar(250)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this._Email = value;
                }
            }
        }

        //[Required]
        [Display(Name = "Loan Amount")]
        [Range(typeof(decimal), "0.00", "99999999.99", ErrorMessage = "Wrong Format")]
        [RegularExpression(@"^(([0-9]+)|([0-9]+\.[0-9]{1,2}))$", ErrorMessage = "Wrong Format")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Loan_Amount", DbType = "NVarChar(250)")]
        public string Loan_Amount
        {
            get
            {
                return this._Loan_Amount;
            }
            set
            {
                if ((this._Loan_Amount != value))
                {
                    this._Loan_Amount = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Paycheck_Period", DbType = "NVarChar(250)")]
        public string Paycheck_Period
        {
            get
            {
                return this._Paycheck_Period;
            }
            set
            {
                if ((this._Paycheck_Period != value))
                {
                    this._Paycheck_Period = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Gross_Income_per_Paycheck", DbType = "NVarChar(250)")]
        public string Gross_Income_per_Paycheck
        {
            get
            {
                return this._Gross_Income_per_Paycheck;
            }
            set
            {
                if ((this._Gross_Income_per_Paycheck != value))
                {
                    this._Gross_Income_per_Paycheck = value;
                }
            }
        }

        public string SubmitFromBtn
        {
            get
            {
                return this._SubmitFromBtn;
            }
            set
            {
                if ((this._SubmitFromBtn != value))
                {
                    this._SubmitFromBtn = value;
                }
            }
        }
        public string SubmitTime
        {
            get
            {
                return this._SubmitTime;
            }
            set
            {
                if ((this._SubmitTime != value))
                {
                    this._SubmitTime = value;
                }
            }
        }

    }

    public class LeapCreditApplicationForm2
    {


      
        private bool _ck_ACH_Authorization;

        private string _Mobile_Number1;
        private string _Mobile_Number2;
        private string _Mobile_Number3;

        private string _Secondary_Phone_Number1;
        private string _Secondary_Phone_Number2;
        private string _Secondary_Phone_Number3;

        private string _Address;

        private string _Address2;

        private string _City;

        private string _State;

        private string _Zip_Code;

        private string _Date_of_Birth;

        private bool _Current_Military;

        

        private string _SubmitFromBtn;

        private string _SubmitTime;

        public LeapCreditApplicationForm2()
        {
        }


        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ck_ACH_Authorization", DbType = "NVarChar(250)")]
        public bool ck_ACH_Authorization
        {
            get
            {
                return this._ck_ACH_Authorization;
            }
            set
            {
                if ((this._ck_ACH_Authorization != value))
                {
                    this._ck_ACH_Authorization = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[Mobile_Number]", Storage = "_Mobile_Number_", DbType = "NVarChar(250)")]
        public string Mobile_Number1
        {
            get
            {
                return this._Mobile_Number1;
            }
            set
            {
                if ((this._Mobile_Number1 != value))
                {
                    this._Mobile_Number1 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[Mobile_Number]", Storage = "_Mobile_Number_", DbType = "NVarChar(250)")]
        public string Mobile_Number2
        {
            get
            {
                return this._Mobile_Number2;
            }
            set
            {
                if ((this._Mobile_Number2 != value))
                {
                    this._Mobile_Number2 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[Mobile_Number]", Storage = "_Mobile_Number_", DbType = "NVarChar(250)")]
        public string Mobile_Number3
        {
            get
            {
                return this._Mobile_Number3;
            }
            set
            {
                if ((this._Mobile_Number3 != value))
                {
                    this._Mobile_Number3 = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Secondary_Phone_Number", DbType = "NVarChar(250)")]
        public string Secondary_Phone_Number1
        {
            get
            {
                return this._Secondary_Phone_Number1;
            }
            set
            {
                if ((this._Secondary_Phone_Number1 != value))
                {
                    this._Secondary_Phone_Number1 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Secondary_Phone_Number", DbType = "NVarChar(250)")]
        public string Secondary_Phone_Number2
        {
            get
            {
                return this._Secondary_Phone_Number2;
            }
            set
            {
                if ((this._Secondary_Phone_Number2 != value))
                {
                    this._Secondary_Phone_Number2 = value;
                }
            }
        }
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Secondary_Phone_Number", DbType = "NVarChar(250)")]
        public string Secondary_Phone_Number3
        {
            get
            {
                return this._Secondary_Phone_Number3;
            }
            set
            {
                if ((this._Secondary_Phone_Number3 != value))
                {
                    this._Secondary_Phone_Number3 = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Address", DbType = "NVarChar(250)")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                if ((this._Address != value))
                {
                    this._Address = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Address2", DbType = "NVarChar(250)")]
        public string Address2
        {
            get
            {
                return this._Address2;
            }
            set
            {
                if ((this._Address2 != value))
                {
                    this._Address2 = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_City", DbType = "NVarChar(250)")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                if ((this._City != value))
                {
                    this._City = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_State", DbType = "NVarChar(250)")]
        public string State
        {
            get
            {
                return this._State;
            }
            set
            {
                if ((this._State != value))
                {
                    this._State = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Zip_Code", DbType = "NVarChar(250)")]
        public string Zip_Code
        {
            get
            {
                return this._Zip_Code;
            }
            set
            {
                if ((this._Zip_Code != value))
                {
                    this._Zip_Code = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Date_of_Birth", DbType = "NVarChar(250)")]
        public string Date_of_Birth
        {
            get
            {
                return this._Date_of_Birth;
            }
            set
            {
                if ((this._Date_of_Birth != value))
                {
                    this._Date_of_Birth = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Current_Military", DbType = "NVarChar(250)")]
        public bool Current_Military
        {
            get
            {
                return this._Current_Military;
            }
            set
            {
                if ((this._Current_Military != value))
                {
                    this._Current_Military = value;
                }
            }
        }

        public string SubmitFromBtn
        {
            get
            {
                return this._SubmitFromBtn;
            }
            set
            {
                if ((this._SubmitFromBtn != value))
                {
                    this._SubmitFromBtn = value;
                }
            }
        }
        public string SubmitTime
        {
            get
            {
                return this._SubmitTime;
            }
            set
            {
                if ((this._SubmitTime != value))
                {
                    this._SubmitTime = value;
                }
            }
        }

    }

    public class LeapCreditApplicationForm3
    {

      

        private string _Drivers_License_NO;

        private string _SSN1;
        private string _SSN2;
        private string _SSN3;

        private string _Job_Title;

        private string _Employer;

        private string _Time_Employed_year;
        private string _Time_Employed_month;

        private string _Supervisor_Phone_Number1;
        private string _Supervisor_Phone_Number2;
        private string _Supervisor_Phone_Number3;

        private string _Employer_Addresss;

        private string _Employer_City;

        private string _Employer_State;

        private string _Employer_Zip_Code;

        private string _Purpose_for_Loan;

        private string _How_did_you_hear_about_LeapCredit;

        private string _SubmitFromBtn;

        private string _SubmitTime;

        public LeapCreditApplicationForm3()
        {
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Drivers_License_NO", DbType = "NVarChar(250)")]
        public string Drivers_License_NO
        {
            get
            {
                return this._Drivers_License_NO;
            }
            set
            {
                if ((this._Drivers_License_NO != value))
                {
                    this._Drivers_License_NO = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SSN", DbType = "NVarChar(250)")]
        public string SSN1
        {
            get
            {
                return this._SSN1;
            }
            set
            {
                if ((this._SSN1 != value))
                {
                    this._SSN1 = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SSN", DbType = "NVarChar(250)")]
        public string SSN2
        {
            get
            {
                return this._SSN2;
            }
            set
            {
                if ((this._SSN2 != value))
                {
                    this._SSN2 = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SSN", DbType = "NVarChar(250)")]
        public string SSN3
        {
            get
            {
                return this._SSN3;
            }
            set
            {
                if ((this._SSN3 != value))
                {
                    this._SSN3 = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Job_Title", DbType = "NVarChar(250)")]
        public string Job_Title
        {
            get
            {
                return this._Job_Title;
            }
            set
            {
                if ((this._Job_Title != value))
                {
                    this._Job_Title = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer", DbType = "NVarChar(250)")]
        public string Employer
        {
            get
            {
                return this._Employer;
            }
            set
            {
                if ((this._Employer != value))
                {
                    this._Employer = value;
                }
            }
        }
        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Time_Employed_year", DbType = "NVarChar(250)")]
        public string Time_Employed_year
        {
            get
            {
                return this._Time_Employed_year;
            }
            set
            {
                if ((this._Time_Employed_year != value))
                {
                    this._Time_Employed_year = value;
                }
            }
        }
        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Time_Employed_month", DbType = "NVarChar(250)")]
        public string Time_Employed_month
        {
            get
            {
                return this._Time_Employed_month;
            }
            set
            {
                if ((this._Time_Employed_month != value))
                {
                    this._Time_Employed_month = value;
                }
            }
        }
        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Supervisor_Phone_Number", DbType = "NVarChar(250)")]
        public string Supervisor_Phone_Number1
        {
            get
            {
                return this._Supervisor_Phone_Number1;
            }
            set
            {
                if ((this._Supervisor_Phone_Number1 != value))
                {
                    this._Supervisor_Phone_Number1 = value;
                }
            }
        }
        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Supervisor_Phone_Number", DbType = "NVarChar(250)")]
        public string Supervisor_Phone_Number2
        {
            get
            {
                return this._Supervisor_Phone_Number2;
            }
            set
            {
                if ((this._Supervisor_Phone_Number2 != value))
                {
                    this._Supervisor_Phone_Number2 = value;
                }
            }
        }
        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Supervisor_Phone_Number", DbType = "NVarChar(250)")]
        public string Supervisor_Phone_Number3
        {
            get
            {
                return this._Supervisor_Phone_Number3;
            }
            set
            {
                if ((this._Supervisor_Phone_Number3 != value))
                {
                    this._Supervisor_Phone_Number3 = value;
                }
            }
        }
        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer_Addresss", DbType = "NVarChar(250)")]
        public string Employer_Addresss
        {
            get
            {
                return this._Employer_Addresss;
            }
            set
            {
                if ((this._Employer_Addresss != value))
                {
                    this._Employer_Addresss = value;
                }
            }
        }
        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer_City", DbType = "NVarChar(250)")]
        public string Employer_City
        {
            get
            {
                return this._Employer_City;
            }
            set
            {
                if ((this._Employer_City != value))
                {
                    this._Employer_City = value;
                }
            }
        }
        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer_State", DbType = "NVarChar(250)")]
        public string Employer_State
        {
            get
            {
                return this._Employer_State;
            }
            set
            {
                if ((this._Employer_State != value))
                {
                    this._Employer_State = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Employer_Zip_Code", DbType = "NVarChar(250)")]
        public string Employer_Zip_Code
        {
            get
            {
                return this._Employer_Zip_Code;
            }
            set
            {
                if ((this._Employer_Zip_Code != value))
                {
                    this._Employer_Zip_Code = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Purpose_for_Loan", DbType = "NVarChar(250)")]
        public string Purpose_for_Loan
        {
            get
            {
                return this._Purpose_for_Loan;
            }
            set
            {
                if ((this._Purpose_for_Loan != value))
                {
                    this._Purpose_for_Loan = value;
                }
            }
        }

        [Required(ErrorMessage = "Required field")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_How_did_you_hear_about_LeapCredit", DbType = "NVarChar(250)")]
        public string How_did_you_hear_about_LeapCredit
        {
            get
            {
                return this._How_did_you_hear_about_LeapCredit;
            }
            set
            {
                if ((this._How_did_you_hear_about_LeapCredit != value))
                {
                    this._How_did_you_hear_about_LeapCredit = value;
                }
            }
        }

        public string SubmitFromBtn
        {
            get
            {
                return this._SubmitFromBtn;
            }
            set
            {
                if ((this._SubmitFromBtn != value))
                {
                    this._SubmitFromBtn = value;
                }
            }
        }
        public string SubmitTime
        {
            get
            {
                return this._SubmitTime;
            }
            set
            {
                if ((this._SubmitTime != value))
                {
                    this._SubmitTime = value;
                }
            }
        }

    }
}