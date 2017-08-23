using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public PropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public PropertiesViewModel Build(PropertiesQuery query)
        {
            IEnumerable<Models.Property> properties = _context.Properties
                .Where(p => p.IsListedForSale)
                .Select(p => new
                {
                    Property = p,
                    Offers = p.Offers.Where(po => po.BuyerUserId == query.CurrentUserId)
                })
                .ToList()
                .Select(x => x.Property)
                .ToList();

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                properties = properties.Where(x => x.StreetName.Contains(query.Search)
                    || x.Description.Contains(query.Search));
            }

            return new PropertiesViewModel
            {
                Properties = properties
                    .ToList()
                    .Select(MapViewModel)
                    .ToList(),
                Search = query.Search
            };
        }

        private static PropertyViewModel MapViewModel(Models.Property property)
        {
            var offer = property.Offers;
            int? offerStatus = null;
            if(offer!=null){
                offerStatus = (int?)offer.OrderByDescending(x=>x.CreatedAt).FirstOrDefault().Status;  
            }

            return new PropertyViewModel
            {
                Id = property.Id,
                StreetName = property.StreetName,
                Description = property.Description,
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyType = property.PropertyType,
                OfferStatus = offerStatus
            };
        }
    }
}