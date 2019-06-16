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
    public class EditCategory : BaseCommand, IEditCategoryCommand
    {
        public EditCategory(Context context) : base(context)
        {
        }

        public void Execute(CategoryDTO request)
        {
            var category = Context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException();
            }

            if (category.Name != request.Name)
            {
                if (Context.Categories.Any(p => p.Name == request.Name))
                {
                    throw new EntityExistException();
                }

                category.Name = request.Name;
            }


            Context.SaveChanges();
        }
    }
}
