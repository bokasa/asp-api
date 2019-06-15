using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.ICommands.Category;
using Application.Queries;
using EfDataAccess;

namespace EfCommands.CategoryCommands
{
    public class GetCategories : BaseCommand, IGetCategoriesCommand
    {
        public GetCategories(Context context) : base(context)
        {
        }

        public IEnumerable<CategoryDTO> Execute(CategoryQuery request)
        {
            var query = Context.Categories.AsQueryable();

            if(request.Name != null)
            {
                query = query.Where(c => c.Name
                .ToLower()
                .Contains(
                   request.Name.ToLower()
                   ));
            }

            return query.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Ads = c.Ads.Select(a => new AdDTO
                {
                    Title = a.Title,
                    Body = a.Body,
                    Price = a.Price,
                    IsShipping = a.IsShipping
                })
            });
        }
    }
}
