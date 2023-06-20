using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAPI.Model
{
    [Keyless]
    public class OrderDetail
    {
        [Required]
        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        [DataType("float")]
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }

}
