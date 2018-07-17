using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaShop.Domain.Entities;
using InstaShop.Domain.Abstract;

namespace InstaShop.Domain.Concrete
{
    public class EFItemRepository : IClothesRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Item> Items
        {
            get { return context.Items; }
        }
    }
}
