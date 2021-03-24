using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KristinsKitchen.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public int IngredientsDBId { get; set; }
        public IngredientsDB IngredientsDB { get; set; }
        [Required]
        public decimal OwnQuantity { get; set; }
        [Required]
        public string OwnQuantityUnit { get; set; }
        [Required]
        [MaxLength(255)]
        public DateTime PurchaseDate { get; set; }
        [Required]
        private DateTime ExpirationDate { get; set; }
        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [Required]
        public int UserProfileId { get; set; }
        public Ingredient ()
        {
            OwnQuantity = IngredientsDB.Quantity;
            OwnQuantityUnit = IngredientsDB.QuantityUnit;            
        }
    }
}
