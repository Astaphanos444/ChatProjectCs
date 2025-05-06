using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace app.src.Model
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set;} = string.Empty;
    }
}