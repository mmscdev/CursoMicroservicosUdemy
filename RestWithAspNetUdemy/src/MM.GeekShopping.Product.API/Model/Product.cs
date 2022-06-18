using MM.GeekShopping.Product.Api.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.GeekShopping.Product.Api.Model
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(0,10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("categoryName")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Column("imageUrl")]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
