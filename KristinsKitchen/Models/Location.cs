using System.ComponentModel.DataAnnotations;

namespace KristinsKitchen.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(12)]
        public string LocationName { get; set; }
    }
}
