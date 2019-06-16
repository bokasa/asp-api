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
    public class CreateUser : BaseCommand, ICreateUserCommand
    {
        public CreateUser(Context context) : base(context)
        {
        }

        public void Execute(UserDTO request)
        {
            if (Context.Users.Any(c => c.Username == request.Username))
            {
                throw new EntityExistException();
            }

            if (Context.Users.Any(c => c.Email == request.Email))
            {
                throw new EntityExistException();
            }

            Context.Users.Add(new Domain.User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            });

            Context.SaveChanges();
        }
    }
}
