using AuthProjectVol1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthProjectVol1.Context
{
    public class AuthContext:DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
