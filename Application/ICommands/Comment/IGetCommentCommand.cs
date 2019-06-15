using Application.DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.Comment
{
    public interface IGetCommentCommand : ICommand<int, CommentDTO>
    {
    }
}
