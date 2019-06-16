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
        private readonly IGetCategoriesCommand _getCommand;
        private readonly IGetCategoryCommand _getOneCommand;
        private readonly IAddCategoryCommand _addCommand;
        private readonly IDeleteCategoryCommand _deleteCategoryCommand;
        private readonly IEditCategoryCommand _editCategoryCommand;

        public CategoryController(IGetCategoriesCommand getCommand, IGetCategoryCommand getOneCommand, IAddCategoryCommand addCommand, IDeleteCategoryCommand deleteCategoryCommand, IEditCategoryCommand editCategoryCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCategoryCommand = deleteCategoryCommand;
            _editCategoryCommand = editCategoryCommand;
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
        public ActionResult Edit(int id, CategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                _editCategoryCommand.Execute(category);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityExistException)
            {
                TempData["error"] = "Category already exist!";
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoryDTO category)
        {
            try
            {
                _deleteCategoryCommand.Execute(category);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }
        }
    }
}