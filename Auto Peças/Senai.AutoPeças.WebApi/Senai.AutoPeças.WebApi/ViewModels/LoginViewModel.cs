using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPeças.WebApi.ViewModels
{
     public class LoginViewModel
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Senha { get; set; }
            //[Required]
            //public string Permissao { get; set; }
    }
    
}
