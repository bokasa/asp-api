using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.ICommands;
using EfDataAccess;

namespace EfCommands
{
    public class CreateAd : BaseCommand, ICreateAdCommand
    {
        public CreateAd(Context context) : base(context)
        {
        }

        public void Execute(AdDTO request)
        {
            Context.Ads.Add(new Domain.Ad
            {
                Title = request.Title,
                Body = request.Body,
                Price = request.Price,
                IsShipping = request.IsShipping,
                CategoryId = request.CategoryId,
                UserId = request.UserId
            });

            Context.SaveChanges();
        }
    }
}
