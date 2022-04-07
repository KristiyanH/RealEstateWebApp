using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.Data.Models
{
    public class Booking
    {
        public int Id { get; init; }

        [Required]
        public DateTime VisitDate { get; set; }

        public string Description { get; init; }

        [Required]
        public int PropertyId { get; init; }

        public Property Property { get; init; }

        [Required]
        public int ClientId { get; init; }

        public Client Client { get; init; }
    }
}
