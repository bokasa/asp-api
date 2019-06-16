using Application.DTO;
using Application.Exceptions;
using Application.ICommands;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class GetAd : BaseCommand, IGetAdCommand
    {
        public GetAd(Context context) : base(context)
        {
        }

        public AdDTO Execute(int request)
        {
            var ad = Context.Ads
                .Include(a => a.Category)
                .Include(a => a.User)
                .Include(a => a.Comments)
                .Include("Category.Ads")
                .FirstOrDefault(a => a.Id == request);

            if(ad == null)
            {
                throw new EntityNotFoundException();
            }

            return new AdDTO
            {
                Id = ad.Id,
                Title = ad.Title,
                Body = ad.Body,
                Price = ad.Price,
                IsShipping = ad.IsShipping,
                Category = new CategoryDTO
                {
                    Id = ad.Category.Id,
                    Name = ad.Category.Name
                }
            };
        }
    }
}
