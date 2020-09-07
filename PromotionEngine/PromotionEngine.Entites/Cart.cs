using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
   public class Cart
    {
        public int Id { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void AddItems(CartItem item)
        {
            CartItems.Add(item);
        }
    }
}
