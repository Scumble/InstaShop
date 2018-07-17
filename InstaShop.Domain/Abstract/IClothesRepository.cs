using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaShop.Domain.Entities;

namespace InstaShop.Domain.Abstract
{
    public interface IClothesRepository
    {
        IEnumerable<Item> Items { get; }
    }
}
