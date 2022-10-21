using System.ComponentModel.DataAnnotations;
using App.Models.Products;

namespace App.Areas.Product.Models
{
    public class CreateProductModel : ProductModel
    {
        [Display(Name = "Chuyên mục")]
        public int[] CategoryIDs {get; set;}
    }
}