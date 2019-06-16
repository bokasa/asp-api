using Application.DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.Category
{
    public interface IEditCategoryCommand : ICommand<CategoryDTO>
    {
    }
}
