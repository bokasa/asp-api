using Application.DTO;
using Application.Exceptions;
using Application.ICommands;
using Application.Queries;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class GetUser : BaseCommand, IGetUserCommand
    {
        public GetUser(Context context) : base(context)
        {
        }

        public UserDTO Execute(int request)
        {
            var user = Context.Users
                .Include(a => a.Comments)
                .FirstOrDefault(a => a.Id == request);

            if (user == null)
            {
                throw new EntityNotFoundException();
            }

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Comments = user.Comments.Select(c => new CommentDTO
                {
                    Text = c.Text
                })
                
            };
        }

    }
}
