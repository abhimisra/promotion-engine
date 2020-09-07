
namespace PromotionEngine.Business
{
    public class CartManager
    {
        IPromotionEngine promotionEngine;
        public CartManager()
        {
            this.promotionEngine = null;
        }
        public CartManager(IPromotionEngine promotionEngine)
        {
            this.promotionEngine = promotionEngine;
        }

        public int CheckoutCart(Cart cart)
        {
            if (promotionEngine != null)
            {
                var discountPrice = promotionEngine.ApplyPromotion(cart);
                return discountPrice;
            }
            return 0;
        }

        public void AddProductToCart(Cart cart, Product product, int quantity)
        {
            cart.AddItems(new CartItem() { Product = product, Quantity = quantity });
        }
    }
}
