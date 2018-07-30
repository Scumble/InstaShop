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
        public void SaveItem(Item item)
        {
            if (item.ItemId == 0)
                context.Items.Add(item);
            else
            {
                Item dbEntry = context.Items.Find(item.ItemId);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Description = item.Description;
                    dbEntry.Price = item.Price;
                    dbEntry.Category = item.Category;
                }
            }
            context.SaveChanges();
        }
    }
}
