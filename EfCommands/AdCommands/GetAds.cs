using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTO;
using Application.ICommands;
using Application.Queries;
using EfDataAccess;

namespace EfCommands.AdCommands
{
    public class GetAds : BaseCommand, IGetAdsCommand
    {
        public GetAds(Context context) : base(context)
        {
        }

        public IEnumerable<AdDTO> Execute(AdQuery request)
        {
            var query = Context.Ads.AsQueryable();

            if (request.Title != null)
            {
                query = query.Where( a => a.Title
                .ToLower()
                .Contains(
                    request.Title.ToLower())
                );
            }
            if (request.Body != null)
            {
                query = query.Where(b => b.Body
               .ToLower()
               .Contains(
                    request.Body.ToLower())
               );
            }
            if (request.Price.HasValue)
            {
                query = query.Where(p => p.Price == request.Price);
            }
            if (request.IsShipping.HasValue)
            {
                query = query.Where(s => s.IsShipping == request.IsShipping);
            }

            return query.Select(s => new AdDTO
            {
                Title = s.Title,
                Body = s.Body,
                Price = s.Price,
                IsShipping = s.IsShipping
            });
        }
    }
}
