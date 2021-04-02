using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KristinsKitchen.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Url]
        [MaxLength(255)]
        public string ImageLocation { get; set; }
        [JsonIgnore]
        public bool IsActive{ get; set; }
        public UserProfile()
        {
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
