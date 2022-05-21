﻿using System.ComponentModel.DataAnnotations;

namespace FunWithRepoDb.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}