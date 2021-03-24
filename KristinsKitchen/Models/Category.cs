using System.ComponentModel.DataAnnotations;

namespace KristinsKitchen.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }
    }
}
