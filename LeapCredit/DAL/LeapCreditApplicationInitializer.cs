using System.Collections.Generic;
using SlarkInc.Models;

namespace SlarkInc.DAL
{
    public class LeapCreditApplicationInitializer : System.Data.Entity.DropCreateDatabaseAlways<LeapCreditApplicationContext>
    {
        protected override void Seed(LeapCreditApplicationContext context)
        {
            var students = new List<LeapCreditApplication>
            {
                new LeapCreditApplication{
                    First_Name="Andy",
                    Last_Name ="George"
                 
           ,Email="George@test.com"
           ,Loan_Amount="George"
           ,Paycheck_Period="George"
           ,Gross_Income_per_Paycheck="George"
           ,ck_ACH_Authorization=true
           ,Mobile_Number1 ="2343423"
           ,Mobile_Number2 ="23423"
           ,Mobile_Number3 ="233"
           ,Secondary_Phone_Number1="George"
           ,Secondary_Phone_Number2="George"
           ,Secondary_Phone_Number3="George"
           ,Address="George"
           ,Address2="George"
           ,City="George"
           ,State="George"
           ,Zip_Code="George"
           ,Date_of_Birth="George"
           ,Current_Military=true
           ,Drivers_License_NO="George"
           ,SSN1="George"
           ,SSN2="George"
           ,SSN3="George"
           ,Job_Title="George"
           ,Employer="George"
           ,Time_Employed_year="1"
           ,Time_Employed_month="5"
           ,Supervisor_Phone_Number1="George"
            ,Supervisor_Phone_Number2="George"
             ,Supervisor_Phone_Number3="George"
           ,Employer_Addresss="George"
           ,Employer_City="George"
           ,Employer_State="George"
           ,Employer_Zip_Code="George"
           ,Purpose_for_Loan="George"
           ,How_did_you_hear_about_LeapCredit="George"
                }
             
            };
            students.ForEach(s => context.LeapCreditApplications.Add(s));
            context.SaveChanges();
        }
    }
}