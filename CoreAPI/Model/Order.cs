using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CoreAPI.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public int MemberId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        [NotNull]
        public float Freight { get; set; }
        [NotMapped]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Member Member { get; set; }
    }
}
