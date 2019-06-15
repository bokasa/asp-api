using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands.Category;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.CategoryCommands
{
    public class GetCategory : BaseCommand, IGetCategoryCommand
    {
        public GetCategory(Context context) : base(context)
        {
        }

        public CategoryDTO Execute(int request)
        {
            var category = Context.Categories
                .Include(a => a.Ads)
                .FirstOrDefault(a => a.Id == request);

            if (category == null)
            {
                throw new EntityNotFoundException();
            }

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Ads = category.Ads.Select(a => new AdDTO
                {
                    Id = a.Id,
                    Title = a.Title,
                    Body = a.Body
                })
                
            };
        }
    }
}
