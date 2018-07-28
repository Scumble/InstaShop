using InstaShop.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IClothesRepository repository;

        public AdminController(IClothesRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Items);
        }
    }
}