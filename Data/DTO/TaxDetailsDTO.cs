using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class TaxDetailsDTO
    {
        public decimal TaxValue { get; set; }
        public TaxDetailsExtraDetailsDTO ExtraDetails { get; set; }
    }
}
