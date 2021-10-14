using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TheTask { get; set; }
        public string Answer { get; set;  }
        public string Theme { get; set; }
        public List<Picture>? Pictures { get; set; }
        public string UserId { get; set; }
    }
}
