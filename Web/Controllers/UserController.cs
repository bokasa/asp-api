using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands;
using Application.ICommands.User;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetUsersCommand _getCommand;
        private IGetUserCommand _getOneCommand;
        private ICreateUserCommand _createUserCommand;
        private IEditUserCommand _editUserCommand;
        private IDeleteUserCommand _deleteUserCommand;

        public UserController(IGetUsersCommand getCommand, IGetUserCommand getOneCommand, ICreateUserCommand createUserCommand, IEditUserCommand editUserCommand, IDeleteUserCommand deleteUserCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _createUserCommand = createUserCommand;
            _editUserCommand = editUserCommand;
            _deleteUserCommand = deleteUserCommand;
        }


        // GET: User
        public ActionResult Index(UserQuery search)
        {
            var users = _getCommand.Execute(search);
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var user = _getOneCommand.Execute(id);
                return View(user);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            try
            {
                _createUserCommand.Execute(user);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                TempData["error"] = "User with same name already exist!";
            }
            catch (Exception)
            {
                TempData["error"] = "User error has occured!";
            }

            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            try
            {
                _editUserCommand.Execute(user);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityExistException)
            {
                TempData["error"] = "User already exist!";
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserDTO user)
        {
            try
            {
                _deleteUserCommand.Execute(user);
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