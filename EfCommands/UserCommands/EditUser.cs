using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands.User;
using EfDataAccess;

namespace EfCommands.UserCommands
{
    public class EditUser : BaseCommand, IEditUserCommand
    {
        public EditUser(Context context) : base(context)
        {
        }

        public void Execute(UserDTO request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException();
            }

            if (user.Username != request.Username)
            {
                if (Context.Users.Any(p => p.Username == request.Username))
                {
                    throw new EntityExistException("This Username  already exist.");
                }

                user.Username = request.Username;
            }

            if (user.Password != request.Password)
            {
                if (Context.Users.Any(p => p.Password == request.Password))
                {
                    throw new EntityExistException("This Password  already exist.");
                }

                user.Password = request.Password;
            }

            if (user.Email != request.Email)
            {
                if (Context.Users.Any(p => p.Email == request.Email))
                {
                    throw new EntityExistException("This Email  already exist.");
                }

                user.Email = request.Email;
            }


            Context.SaveChanges();
        }
    }
}
