using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RedSquirrel.Data.Entities
{
    public class User 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 UserId { get; set; }
        public String ExternalUserId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
    }
}