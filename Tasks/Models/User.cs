using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.Models
{
    public class User : IdentityUser
    {
        public List<Task> Tasks { get; set; }
        public string? Language { get; set; }
        public string? Theme { get; set; }
    }
}
