using OrangeBricks.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;
namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeAppointmentCommand
    {
        [Required]
        public int PropertyId { get; set; }
        [Display(Name = "Appointment Date"), DataType(DataType.DateTime)]
        [FutureDate(ErrorMessage = "Please enter a date in the future, from Monday to Friday, 9AM-6PM")]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string BuyerUserId { get; set; }
        [Required]
        public string StreetName { get; set; }
    }
}