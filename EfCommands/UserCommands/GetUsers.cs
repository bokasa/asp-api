using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.ICommands;
using Application.Queries;
using EfDataAccess;

namespace EfCommands.AdCommands
{
    public class GetUsers : BaseCommand, IGetUsersCommand
    {
        public GetUsers(Context context) : base(context)
        {
        }

        public IEnumerable<UserDTO> Execute(UserQuery request)
        {
            var query = Context.Users.AsQueryable();

            if (request.Username != null)
            {
                query = query.Where(u => u.Username
               .ToLower()
               .Contains(
                   request.Username.ToLower()));
            }

            if (request.Email != null)
            {
                query = query.Where(u => u.Email
               .ToLower()
               .Contains(
                   request.Email.ToLower()));
            }

            return query.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Comments = u.Comments.Select( c => new CommentDTO
                {
                    Text = c.Text
                })
            });
        }
    }
}
