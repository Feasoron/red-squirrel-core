using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RedSquirrel.Models
{
    public class User 
    {
        public Int64 UserId { get; set; }
        public String ExternalUserId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
    }
}