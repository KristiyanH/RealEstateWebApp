﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateWebApp.Data.Models
{
    public class Property
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(DataConstants.ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(DataConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public int BuildingYear { get; set; }

        public int? Floor { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal SquareMeters { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PricePerSquareMeter
            => Price / SquareMeters;

        [Required]
        public int PropertyTypeId { get; set; }

        public PropertyType PropertyType { get; init; }
    }
}
