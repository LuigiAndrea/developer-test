using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MakeAppointmentViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MakeAppointmentViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MakeAppointmentViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);
            DateTime date = DateTime.Now;
         
            return new MakeAppointmentViewModel
            {
                PropertyId = property.Id,
                AppointmentDate = date,
                StreetName = property.StreetName
            };
        }
    }
}
