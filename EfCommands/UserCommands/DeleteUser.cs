using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands.User;
using EfDataAccess;

namespace EfCommands.UserCommands
{
    public class DeleteUser : BaseCommand, IDeleteUserCommand
    {
        public DeleteUser(Context context) : base(context)
        {
        }

        public void Execute(UserDTO request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException();
            }

            user.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
