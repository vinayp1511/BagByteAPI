using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BagByteAPI.Models
{
    public class RegisterUser
    {
        public long UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }

        public DateTime DoB { get; set; }
    //    public long UserRoleID { get; set; }
      //  public string UserRole { get; set; }
    }

    public class VerifyUser
    {
        public long UserID { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
    }
}