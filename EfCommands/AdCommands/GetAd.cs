using Application.DTO;
using Application.Exceptions;
using Application.ICommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.AdCommands
{
    public class GetAd : BaseCommand, IGetAdCommand
    {
        public GetAd(Context context) : base(context)
        {
        }

        public AdDTO Execute(int request)
        {
            var ad = Context.Ads.Find(request);

            if(ad == null)
            {
                throw new EntityNotFoundException();
            }

            return new AdDTO
            {
                Title = ad.Title,
                Body = ad.Body,
                Price = ad.Price,
                IsShipping = ad.IsShipping
            };
        }
    }
}
