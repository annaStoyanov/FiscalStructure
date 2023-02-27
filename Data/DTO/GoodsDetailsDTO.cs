using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class GoodsDetailsDTO
    {
        public string Item { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountValue { get; set; }
        public int Qty { get; set; }
        public GoodDetailsExtraDetailsDTO ExtraDetails { get; set; }

    }
}
