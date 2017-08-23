using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SlarkInc.Models;
using SlarkInc.DBHelpers;

namespace SlarkInc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LeapCreditApplicationForm1 model = new Models.LeapCreditApplicationForm1();

            return View(model);
           
        }
        [HttpPost]
        public ActionResult Step2(LeapCreditApplicationForm1 modelForm1, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                LeapCreditApplication applyModel = new LeapCreditApplication();
                applyModel.First_Name = modelForm1.First_Name;
            applyModel.Last_Name = modelForm1.Last_Name;
            applyModel.SubmitFromBtn = "Step1NextBtn";
            applyModel.Loan_Amount = collection["amount"];
            applyModel.Paycheck_Period = modelForm1.Paycheck_Period;
            applyModel.Gross_Income_per_Paycheck = modelForm1.Gross_Income_per_Paycheck;
            applyModel.Email = modelForm1.Email;


                TempData["Loan_Amount"] = applyModel.Loan_Amount;
                TempData["Paycheck_Period"] = modelForm1.Paycheck_Period;
                TempData["Gross_Income_per_Paycheck"] = modelForm1.Gross_Income_per_Paycheck;
                //List<LeapCreditApplication> file_to_DMS_List = new List<LeapCreditApplication>();
                //file_to_DMS_List = SQLDatabase.GetAllLeapCreditApplication_bySSN(model.SSN);

                //if (file_to_DMS_List.Count == 1)
                //{
                //    LeapCreditApplication jc_model = file_to_DMS_List[0];
                //    //applyModel.SubmitFromIPAddress = HttpContext.ApplicationInstance.Context.Request.RequestContext.HttpContext.Request.UserHostAddress;

                //}

                SQLDatabase.InsertStep1Insert_LeapCreditApplication(applyModel);

                //string redirectUrl = "https://clearoneadvantage.com/thank-you.php?Lead_ID=3&button.x=141&formurl=https%3A%2F%2Fwww.clearoneadvantage.com%2Fapply.php&token=16acfaefb1814e93fef8f32e8a6c15f4&lastname=Benjamin&ldsrc=3&xxLeadId=05bmsztg7&button.y=12&firstname=Daniel&emailaddress=dbenjamin%40lendingsciencedm.com&state=FL&debt=30000&homephone=9419625605";
                //string redirectUrl = "https://clearoneadvantage.com/thank-you.php?Lead_ID=3&button.x=141&formurl=https%3A%2F%2Fwww.clearoneadvantage.com%2Fapply.php&token=16acfaefb1814e93fef8f32e8a6c15f4&lastname=" + applyModel.LastName + "&ldsrc=3&xxLeadId=05bmsztg7&button.y=12&firstname=" + applyModel.FirstName + "&emailaddress=" + applyModel.Email + "&state=" + applyModel.State + "&debt=" + applyModel.DebtAmount + "&homephone=" + applyModel.Phone + "";
                //Response.RedirectPermanent(redirectUrl);
                LeapCreditApplicationForm2 modelForm2 = new Models.LeapCreditApplicationForm2();
                return View("Step2", modelForm2);
            }
            else
            {
                return View("Index", modelForm1);
            }
        }

        public ActionResult Step3(LeapCreditApplicationForm2 applyModelForm2, FormCollection collection)
        {
            if (ModelState.IsValid)
            {

                //applyModel.First_Name = model.First_Name;
                //applyModel.Last_Name = model.Last_Name;
                applyModelForm2.SubmitFromBtn = "Step2ContinueAppBtn";
                //applyModel.Loan_Amount = collection["amount"];
                //applyModel.Paycheck_Period = model.Paycheck_Period;
                //applyModel.Gross_Income_per_Paycheck = model.Gross_Income_per_Paycheck;
                //applyModel.Email = model.Email;

                LeapCreditApplication lca = new Models.LeapCreditApplication();
                lca.ck_ACH_Authorization = applyModelForm2.ck_ACH_Authorization;
                lca.Mobile_Number1 = applyModelForm2.Mobile_Number1;
                lca.Mobile_Number2 = applyModelForm2.Mobile_Number2;
                lca.Mobile_Number3 = applyModelForm2.Mobile_Number3;
                lca.Secondary_Phone_Number1 = applyModelForm2.Secondary_Phone_Number1;
                lca.Secondary_Phone_Number2 = applyModelForm2.Secondary_Phone_Number2;
                lca.Secondary_Phone_Number3 = applyModelForm2.Secondary_Phone_Number3;
                lca.Address = applyModelForm2.Address;
                lca.Address2 = applyModelForm2.Address2;
                lca.City = applyModelForm2.City;
                lca.State = applyModelForm2.State;
                lca.Zip_Code = applyModelForm2.Zip_Code;
                lca.Date_of_Birth = applyModelForm2.Date_of_Birth;
                lca.Current_Military = applyModelForm2.Current_Military;

                //List<LeapCreditApplication> file_to_DMS_List = new List<LeapCreditApplication>();
                //file_to_DMS_List = SQLDatabase.GetAllLeapCreditApplication_bySSN(model.SSN);

                //if (file_to_DMS_List.Count == 1)
                //{
                //    LeapCreditApplication jc_model = file_to_DMS_List[0];
                //    //applyModel.SubmitFromIPAddress = HttpContext.ApplicationInstance.Context.Request.RequestContext.HttpContext.Request.UserHostAddress;

                //}

                SQLDatabase.InsertStep2_LeapCreditApplication(lca);

                //string redirectUrl = "https://clearoneadvantage.com/thank-you.php?Lead_ID=3&button.x=141&formurl=https%3A%2F%2Fwww.clearoneadvantage.com%2Fapply.php&token=16acfaefb1814e93fef8f32e8a6c15f4&lastname=Benjamin&ldsrc=3&xxLeadId=05bmsztg7&button.y=12&firstname=Daniel&emailaddress=dbenjamin%40lendingsciencedm.com&state=FL&debt=30000&homephone=9419625605";
                //string redirectUrl = "https://clearoneadvantage.com/thank-you.php?Lead_ID=3&button.x=141&formurl=https%3A%2F%2Fwww.clearoneadvantage.com%2Fapply.php&token=16acfaefb1814e93fef8f32e8a6c15f4&lastname=" + applyModel.LastName + "&ldsrc=3&xxLeadId=05bmsztg7&button.y=12&firstname=" + applyModel.FirstName + "&emailaddress=" + applyModel.Email + "&state=" + applyModel.State + "&debt=" + applyModel.DebtAmount + "&homephone=" + applyModel.Phone + "";
                //Response.RedirectPermanent(redirectUrl);
                LeapCreditApplicationForm3 lca3 = new LeapCreditApplicationForm3();
                return View("Step3", lca3);
            }
            else
            {
                //TempData["Loan_Amount"] = applyModelForm2.Loan_Amount;
                //TempData["Paycheck_Period"] = applyModelForm2.Paycheck_Period;
                return View("Step2", applyModelForm2);
            }
        }

        public ActionResult ThankYou(LeapCreditApplicationForm3 applyModelForm3, FormCollection collection)
        {
            if (ModelState.IsValid)
            {

                //applyModel.First_Name = model.First_Name;
                //applyModel.Last_Name = model.Last_Name;
                applyModelForm3.SubmitFromBtn = "Step3ContinueAppBtn";
            //applyModel.Loan_Amount = collection["amount"];
            //applyModel.Paycheck_Period = model.Paycheck_Period;
            //applyModel.Gross_Income_per_Paycheck = model.Gross_Income_per_Paycheck;
            //applyModel.Email = model.Email;

            LeapCreditApplication lca = new Models.LeapCreditApplication();
            lca.Drivers_License_NO = applyModelForm3.Drivers_License_NO;
            lca.SSN1 = applyModelForm3.SSN1;
            lca.SSN2 = applyModelForm3.SSN2;
            lca.SSN3 = applyModelForm3.SSN3;
            lca.Job_Title = applyModelForm3.Job_Title;
            lca.Employer = applyModelForm3.Employer;
            lca.Time_Employed_year = applyModelForm3.Time_Employed_year;
            lca.Time_Employed_month = applyModelForm3.Time_Employed_month;
            lca.Supervisor_Phone_Number1 = applyModelForm3.Supervisor_Phone_Number1;
            lca.Supervisor_Phone_Number2 = applyModelForm3.Supervisor_Phone_Number2;
            lca.Supervisor_Phone_Number3 = applyModelForm3.Supervisor_Phone_Number3;
            lca.Employer_Addresss = applyModelForm3.Employer_Addresss;
            lca.Employer_City = applyModelForm3.Employer_City;
            lca.Employer_State = applyModelForm3.Employer_State;
            lca.Employer_Zip_Code = applyModelForm3.Employer_Zip_Code;
            lca.Purpose_for_Loan = applyModelForm3.Purpose_for_Loan;
            lca.How_did_you_hear_about_LeapCredit = applyModelForm3.How_did_you_hear_about_LeapCredit;
          

            SQLDatabase.InsertStep3_LeapCreditApplication(lca);

            //string redirectUrl = "https://clearoneadvantage.com/thank-you.php?Lead_ID=3&button.x=141&formurl=https%3A%2F%2Fwww.clearoneadvantage.com%2Fapply.php&token=16acfaefb1814e93fef8f32e8a6c15f4&lastname=Benjamin&ldsrc=3&xxLeadId=05bmsztg7&button.y=12&firstname=Daniel&emailaddress=dbenjamin%40lendingsciencedm.com&state=FL&debt=30000&homephone=9419625605";
            string redirectUrl = "https://leapcredit.com/";
            Response.RedirectPermanent(redirectUrl);
            return RedirectToAction("Index");
            }
            else
            {
                return View("Step3", applyModelForm3);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}