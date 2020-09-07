using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class PromotionRule
    {
        public int ProductId { get; set; }
        public int MinimumQuantity { get; set; }
        public int Reduction { get; set; }

        public List<int> RequiredOtherProducts { get; set; }
    }
}
