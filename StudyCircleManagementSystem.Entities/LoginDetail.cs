using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudyCircleManagementSystem.Web.Models
{
    public class LoginDetail
    {
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
        public string Designation { get; set; }
    }
}