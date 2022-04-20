using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

    }


}

