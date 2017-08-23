using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace SlarkInc.Models
{

    public class JC_Model
    {
        public string FirstName { get; set; }
		
        public string LastName { get; set; }
        public string Address { get; set; }
       
        public string City { get; set; }
        public string State { get; set; }
        public string StateDescription { get; set; }
        public string Zip5 { get; set; }
        public string Zipfour { get; set; }
        public string Company { get; set; }

        public string Purpose_Of_Loan { get; set; }
        public string Best_Time_to_Call { get; set; }
        public string PO_Box { get; set; }
        public string Date_Of_Birth { get; set; }
        

        //[Required(ErrorMessage = "Enter Email first", AllowEmptyStrings = false)]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please input a valid email address.")]
        public string Email { get; set; }

        public string TitleCode { get; set; }
        public string TitleCodeDescription { get; set; }

        //[RegularExpression(@"^\([0-9]{3}\)\s[0-9]{3}-[0-9]{4}$|^\([_]{3}\)\s[_]{3}-[_]{4}$|^$",ErrorMessage = "Phone doesn’t look like a valid phone.")]
        public string Phone { get; set; }
        //[StringLength(6, ErrorMessage = "Please provide ListID", MinimumLength = 5)]
        //[Required(ErrorMessage = "Enter activation code first", AllowEmptyStrings = false)]
        //[DataType(DataType.Text)]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Invalid activation code")]
        //[Display(Name = "ListId")]
        //[StringLength(5, MinimumLength = 5)]
        [Required(ErrorMessage = "*Please enter your offer code.", AllowEmptyStrings = false)]
        public string Activation_code { get; set; }
        public string Webpage { get; set; }

		  public string camp_id { get; set; }

        public string DebtAmount { get; set; }


    }

   
}
