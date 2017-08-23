using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace SlarkInc.Models
{

    public class MM_ApplyModel
    {
        [Required(ErrorMessage = "*Enter your first name.", AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*Enter your last name.", AllowEmptyStrings = false)]
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string StateDescription { get; set; }
        public string Zip5 { get; set; }
        public string Zipfour { get; set; }
        public string Company { get; set; }
        public string DebtAmount { get; set; }


        public string TitleCode { get; set; }
        public string TitleCodeDescription { get; set; }
      
        [Required(ErrorMessage = "*Enter your phone.", AllowEmptyStrings = false)]
        public string Phone { get; set; }
       
        [Required(ErrorMessage = "*Enter your offer code.", AllowEmptyStrings = false)]
        public string Activation_code { get; set; }
        public string SubmitFromBtn { get; set; }
        public string SubmitFromIPAddress { get; set; }

		  public string camp_id { get; set; }
       
    }

   
}
