using System.ComponentModel.DataAnnotations;
using App.Models.Products;

namespace App.Areas.Product.Models
{
    public class CartItem
    {
        public int quantity { set; get; }
        public ProductModel product { set; get; }
    }
}