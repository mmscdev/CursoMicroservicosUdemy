using System.Collections.Generic;

namespace GeekShopping.Web.Models
{
    public class CartViewModel
    {
        public CartHeaderViewModel CartHeader { get; set; }
        public IEnumerable<CartDetailViewModel> CartDetails { get; set; }
    }



    public class CouponViewModel2
    {
        public string UserId { get; set; }
        public string Coupon { get; set; }
    }
}
