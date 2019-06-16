using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands;
using EfDataAccess;

namespace EfCommands
{
    public class DeleteAd : BaseCommand, IDeleteAdCommand
    {
        public DeleteAd(Context context) : base(context)
        {
        }

        public void Execute(AdDTO request)
        {
            var ad = Context.Ads.Find(request.Id);

            if (ad == null)
            {
                throw new EntityNotFoundException();
            }

            ad.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
