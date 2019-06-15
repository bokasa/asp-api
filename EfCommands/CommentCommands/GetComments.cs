using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.ICommands.Comment;
using Application.Queries;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.CommentCommands
{
    public class GetComments : BaseCommand, IGetCommentsCommand
    {
        public GetComments(Context context) : base(context)
        {
        }

        public IEnumerable<CommentDTO> Execute(CommentQuery request)
        {
            var query = Context.Comments.AsQueryable();

            query.Include(c => c.Ad);

            if(request.Text != null)
            {
                query = query.Where(c => c.Text
               .ToLower()
               .Contains(request.Text.ToLower()));
            }

            return query.Select(c => new CommentDTO
            {
                Id = c.Id,
                Text = c.Text,
                Ad = new AdDTO
                {
                    Id = c.Id,
                    Title = c.Ad.Title,
                    Body = c.Ad.Body,
                    Price = c.Ad.Price,
                    IsShipping = c.Ad.IsShipping
                }

            }) ;
        }
    }
}
