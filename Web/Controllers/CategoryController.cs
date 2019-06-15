using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands.Category;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private IGetCategoriesCommand _getCommand;
        private IGetCategoryCommand _getOneCommand;
        private IAddCategoryCommand _addCommand;

        public CategoryController(IGetCategoriesCommand getCommand, IGetCategoryCommand getOneCommand, IAddCategoryCommand addCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
        }

        // GET: Category
        public ActionResult Index(CategoryQuery search)
        {
            var categories = _getCommand.Execute(search);
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var category = _getOneCommand.Execute(id);
                return View(category);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryDTO collection)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }

            try
            {
                _addCommand.Execute(collection);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                TempData["error"] = "Post with same name already exist!";
            }
            catch (Exception)
            {
                TempData["error"] = "An error has occured!";
            }

            return View();
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}