using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.Client.Models
{
    public class UserViewModel
    {
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string passWord { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public UserViewModel()
        {

        }
    }
}
