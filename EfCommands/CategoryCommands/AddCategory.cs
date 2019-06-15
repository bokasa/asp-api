using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands.Category;
using EfDataAccess;

namespace EfCommands.CategoryCommands
{
    public class AddCategory : BaseCommand, IAddCategoryCommand
    {
        public AddCategory(Context context) : base(context)
        {
           
        }

        public void Execute(CategoryDTO request)
        {
            if (Context.Categories.Any(c => c.Name == request.Name))
            {
                throw new EntityNotFoundException();
            }
            Context.Categories.Add(new Domain.Category
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
