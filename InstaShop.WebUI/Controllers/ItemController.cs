using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstaShop.Domain.Abstract;
using InstaShop.Domain.Entities;
using InstaShop.WebUI.Models;

namespace InstaShop.WebUI.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        private IClothesRepository repository;
        public int pageSize = 4;

        public ItemController(IClothesRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(int page=1)
        {
            ItemsListViewModel model = new ItemsListViewModel
            {
                Items = repository.Items
                     .OrderBy(item => item.ItemId)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Items.Count()
                }
            };
            return View(model);
        }
    }
}