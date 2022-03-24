﻿using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;

namespace RealEstateWebApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(JobDescriptionMaxValue)]
        public string Description { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}