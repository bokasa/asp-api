using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands;
using EfDataAccess;

namespace EfCommands
{
    public class EditAd : BaseCommand, IEditAdCommand
    {
        public EditAd(Context context) : base(context)
        {
        }

        public void Execute(AdDTO request)
        {
            var ad = Context.Ads.Find(request.Id);

            if (ad == null)
            {
                throw new EntityNotFoundException();
            }

            if (ad.Title != request.Title)
            {
                if (Context.Ads.Any(p => p.Title == request.Title))
                {
                    throw new EntityExistException("This Title already exist.");
                }

                ad.Title = request.Title;
            }

            if (ad.Body != request.Body)
            {
                if (Context.Ads.Any(p => p.Body == request.Body))
                {
                    throw new EntityExistException("This Body already exist.");
                }

                ad.Body = request.Body;
            }

            ad.Price = request.Price;

            ad.IsShipping = request.IsShipping;

            Context.SaveChanges();
        }
    }
}
