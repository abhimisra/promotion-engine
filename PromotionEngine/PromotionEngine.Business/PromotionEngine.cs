using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionEngine : IPromotionEngine
    {
        public List<PromotionRule> promotionRules = new List<PromotionRule>()
        {
           new PromotionRule(){ProductId=1,MinimumQuantity=3,Reduction=20},
           new PromotionRule(){ProductId=2,MinimumQuantity=2,Reduction=15},
           new PromotionRule(){ProductId=3,MinimumQuantity=1,Reduction=5,RequiredOtherProducts=new List<int>(){ 4} }
        };

        public void AddNewPromotionRule(PromotionRule promotionRule)
        {
            promotionRules.Add(promotionRule);
        }

        public int ApplyPromotion(Cart cart)
        {
            int reducedFinalPrice = 0;
            var items = cart.CartItems;

            foreach (var item in items)
            {

                var reduction = promotionRules.Where(x => x.ProductId == item.Product.Id).Select(y => y.Reduction).FirstOrDefault();
                var minQuantity = promotionRules.Where(x => x.ProductId == item.Product.Id).Select(y => y.MinimumQuantity).FirstOrDefault();
                var otherRequiredProduct = promotionRules.Where(x => x.ProductId == item.Product.Id).Select(y => y.RequiredOtherProducts).FirstOrDefault();

                if (!item.IsProcessed)
                {
                    if (reduction != 0)
                    {
                        // promotion rule exist for product

                        if (otherRequiredProduct == null)
                        {
                            int itemDiff = item.Quantity - minQuantity;
                            while (itemDiff >= 0)
                            {
                                reducedFinalPrice += item.Product.Price * minQuantity - reduction;

                                item.Quantity = item.Quantity - minQuantity;

                                if (item.Quantity < minQuantity-1)
                                {
                                    break;
                                }
                                else
                                {
                                    itemDiff = item.Quantity - minQuantity;
                                }
                            }
                            if (item.Quantity > 0)
                            {
                                reducedFinalPrice += item.Product.Price * item.Quantity;
                            }
                        }
                        else
                        {
                            int count = 0;
                            foreach (var req in otherRequiredProduct)
                            {
                                var requiredProduct = cart.CartItems.Where(x => x.Product.Id == req).FirstOrDefault();
                                if (requiredProduct != null)
                                {
                                    count++;
                                }
                            }
                            if (count >= otherRequiredProduct.Count())
                            {
                                var requiredProductPrice = 0;
                                foreach (var req in otherRequiredProduct)
                                {
                                    var price = cart.CartItems.Where(x => x.Product.Id == req).Select(y => y.Product.Price).FirstOrDefault();
                                    items.Where(x => x.Product.Id==req).Select(y=> { y.IsProcessed = true; return y; }).ToList();
                                    requiredProductPrice += price;
                                }
                                reducedFinalPrice += item.Product.Price + requiredProductPrice - reduction;
                            }
                            else
                            {
                                reducedFinalPrice += item.Product.Price * item.Quantity;
                            }
                        }
                    }
                    else
                    {
                        reducedFinalPrice += item.Product.Price * item.Quantity;
                    }
                }

            }
            return reducedFinalPrice;
        }
    }
}
