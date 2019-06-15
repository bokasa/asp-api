using Application.DTO;
using Application.Interfaces;
using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.Comment
{
    public interface IGetCommentsCommand : ICommand<CommentQuery,IEnumerable<CommentDTO>>
    {
    }
}
