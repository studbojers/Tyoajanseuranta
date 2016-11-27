using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tyoajanseuranta5.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Required: Firstname.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required: Lastname.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Required: Email Address.")]
        [EmailAddress(ErrorMessage = "Required: Valid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required: Username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required: Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public class Workinghours
    {
        [Key]
        public int KeyIndex { get; set; }

        [Required(ErrorMessage = "Required: UserID")]
        public int UserID { get; set; }

        public DateTime DateTime { get; set; }
        
        /// <summary>
        /// Direction: 0=out, 1=in 
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// Reason: 0=normal, 1=lunch, 2=sick, 3=personal 
        /// </summary>
        public int Reason { get; set; }
    }
}