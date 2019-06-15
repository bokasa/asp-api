using Application.DTO;
using Application.Interfaces;
using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.Category
{
    public interface IGetGetCommentsCommand : ICommand<CategoryQuery, IEnumerable<CategoryDTO>>
    {
    }
}
