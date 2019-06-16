using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands.Category;
using EfDataAccess;

namespace EfCommands.CategoryCommands
{
    public class DeleteCategory : BaseCommand, IDeleteCategoryCommand
    {
        public DeleteCategory(Context context) : base(context)
        {
        }

        public void Execute(CategoryDTO request)
        {
            var category = Context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException();
            }

            category.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
