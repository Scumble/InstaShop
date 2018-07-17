using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstaShop.Domain.Abstract;
using InstaShop.Domain.Entities;

namespace InstaShop.WebUI.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        private IClothesRepository repository;
        public ItemController(IClothesRepository repo)
        {
            repository = repo;
        }
        public ViewResult List()
        {
            return View(repository.Items);
        }
    }
}