using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BuyerUserId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

    }
}