using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands.Comment;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.CommentCommands
{
    public class GetComment : BaseCommand, IGetCommentCommand
    {
        public GetComment(Context context) : base(context)
        {
            
        }

        public CommentDTO Execute(int request)
        {
            var comment = Context.Comments
                .Include(c => c.Ad)
                .FirstOrDefault(a => a.Id == request);

            if (comment == null)
            {
                throw new EntityNotFoundException();
            }

            return new CommentDTO
            {
                Id = comment.Id,
                Text = comment.Text,
                Ad = new AdDTO
                {
                    Id = comment.Id,
                    Title = comment.Ad.Title,
                    Body = comment.Ad.Body,
                    Price = comment.Ad.Price,
                    IsShipping = comment.Ad.IsShipping
                }
            };
        }
    }
}
