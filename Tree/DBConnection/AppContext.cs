using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DBConnection
{
    internal class AppContext : DbContext
    {
        public AppContext() : base("Tree")
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Tree> Tree { get; set; }
        public DbSet<UserTreeMapping> UserTreeMapping { get; set; }
        public DbSet<TreeNode> TreeNode { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
