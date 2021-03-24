using System.ComponentModel.DataAnnotations;

namespace KristinsKitchen.Models
{
    public class IngredientsDB
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string Brand { get; set; }
        [MaxLength(255)]
        public string Variety { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        [MaxLength(20)]
        public string QuantityUnit { get; set; }
        [MaxLength(255)]
        public string ContainerType { get; set; }
        [Required]
        public int PantryShelfLife { get; set; }
        [Required]
        public int FridgeShelfLife { get; set; }
        [Required]
        public int FreezerShelfLife { get; set; }
        [MaxLength(255)]
        public string ImageLocation { get; set; }
    }
}
