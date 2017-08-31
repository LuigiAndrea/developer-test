using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeAppointmentCommandHandler
    {

        private readonly IOrangeBricksContext _context;

        public MakeAppointmentCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(MakeAppointmentCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            DateTime d = new DateTime(command.AppointmentDate.Year,command.AppointmentDate.Month, command.AppointmentDate.Day,command.AppointmentDate.Hour,command.AppointmentDate.Minute,0);

            var appointment  = new Appointment
            {
               Id = command.PropertyId,
               AppointmentDate = command.AppointmentDate,
               BuyerUserId = command.BuyerUserId,   
            };

            if (property.Appointments == null)
            {
                property.Appointments = new List<Appointment>();
            }

            property.Appointments.Add(appointment);

            _context.SaveChanges();
        }

    }
}