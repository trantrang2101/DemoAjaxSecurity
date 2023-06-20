using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoreAPI.Model
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        public string Email { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        [Required]
        public string Password { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }
    }

}
