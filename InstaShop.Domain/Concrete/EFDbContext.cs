using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaShop.Domain.Entities;
using System.Data.Entity;

namespace InstaShop.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}
