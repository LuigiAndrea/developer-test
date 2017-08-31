using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;
using OrangeBricks.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;


namespace OrangeBricks.Web.Controllers.Appointments.Builders
{
    public class AppointmentsOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;
        public AppointmentsOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public AppointmentsOnPropertyViewModel Build(int id)
        {
            var property = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Appointments)
                .SingleOrDefault();

            var appointments = property.Appointments ?? new List<Appointment>();
            var um = new UserManager<ApplicationUser>(
              new UserStore<ApplicationUser>(new ApplicationDbContext()));

            return new AppointmentsOnPropertyViewModel
            {
                HasAppointments = appointments.Any(),
                Appointments = appointments.Select(x => new AppointmentViewModel
                {
                    Id = x.Id,
                    AppointmentDate=x.AppointmentDate,
                    Email = um.FindById(x.BuyerUserId).Email
                }).OrderBy(d=>d.AppointmentDate),
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms
            };
        }
    }
}