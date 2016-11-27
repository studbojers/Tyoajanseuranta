using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tyoajanseuranta5.Models
{
    public class TyoajanseurantaDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }

        public DbSet<Workinghours> workinghours { get; set; }
    }
}