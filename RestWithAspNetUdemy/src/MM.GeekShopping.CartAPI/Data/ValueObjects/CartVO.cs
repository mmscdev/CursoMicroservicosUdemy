using System.Collections.Generic;

namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CartVO
    {
        public CartHeaderVO CartHeader { get; set; }
        public IEnumerable<CartDetailVO> CartDetails { get; set; }
    }

    public class CouponVO
    {
        public string UserId { get; set; }
        public string Coupon { get; set; }
    }
}
