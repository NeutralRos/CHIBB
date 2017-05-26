using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace CHIBB.Models
{
    public class UserAccount
    {
		[Key]
		public int UserID { get; set; }

		[Required(ErrorMessage = "First name is required" )]
		public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage ="Please enter a valid E mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "user name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "password is required")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
		[Compare("Password",ErrorMessage ="Please confirm password")]
		[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
