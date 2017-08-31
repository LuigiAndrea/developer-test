using System;
using System.ComponentModel.DataAnnotations;
namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class MakeAppointmentViewModel
    {
        public DateTime AppointmentDate { get; set; }
        public int PropertyId { get; set; }
        public string StreetName { get; set; }
    }
}