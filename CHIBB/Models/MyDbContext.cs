using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CHIBB.Models
{
    public class MyDbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}
