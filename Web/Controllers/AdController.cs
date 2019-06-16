using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands;
using Application.Interfaces;
using Application.Queries;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AdController : Controller
    {
        private readonly Context _context;
        private IGetAdsCommand _getCommand;
        private IGetAdCommand _getOneCommand;
        private ICreateAdCommand _createAdCommand;
        private IDeleteAdCommand _deleteAdCommand;
        private IEditAdCommand _editAdCommand;

        public AdController(Context context, IGetAdsCommand getCommand, IGetAdCommand getOneCommand, ICreateAdCommand createAdCommand, IDeleteAdCommand deleteAdCommand, IEditAdCommand editAdCommand)
        {
            _context = context;
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _createAdCommand = createAdCommand;
            _deleteAdCommand = deleteAdCommand;
            _editAdCommand = editAdCommand;
        }


        // GET: Ad
        public ActionResult Index(AdQuery search)
        {
            var ad = _getCommand.Execute(search);
            return View(ad);
        }

        // GET: Ad/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var ad = _getOneCommand.Execute(id);
                return View(ad);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Ad/Create
        public ActionResult Create()
        {
            ViewBag.Users = _context.Users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username
            });
            ViewBag.Categories = _context.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });

            return View();
        }

        // POST: Ad/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdDTO ad)
        {
            if (!ModelState.IsValid)
            {
                return View(ad);
            }

            try
            {
                _createAdCommand.Execute(ad);

                return RedirectToAction(nameof(Index));
                
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }

        }

        // GET: Ad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdDTO ad)
        {
            if (!ModelState.IsValid)
            {
                return View(ad);
            }

            try
            {
                _editAdCommand.Execute(ad);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityExistException)
            {
                TempData["error"] = "Ad already exist!";
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();

        }

    // GET: Ad/Delete/5
    public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ad/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AdDTO ad)
        {
            try
            {
                _deleteAdCommand.Execute(ad);
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