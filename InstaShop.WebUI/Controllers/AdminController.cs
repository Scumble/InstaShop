using InstaShop.Domain.Abstract;
using InstaShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaShop.WebUI.Controllers
{
    [Authorize]
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
        public ViewResult Edit(int itemId)
        {
            Item item = repository.Items
                .FirstOrDefault(g => g.ItemId == itemId);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                repository.SaveItem(item);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", item.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(item);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Item());
        }
        [HttpPost]
        public ActionResult Delete(int? itemId)
        {
            Item deletedItem = repository.DeleteItem(itemId);
            if (deletedItem != null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    deletedItem.Name);
            }
            return RedirectToAction("Index");
        }
    }
}