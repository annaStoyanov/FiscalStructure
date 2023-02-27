using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class CommonObjectDTO 
    {
        public BasicInformationDTO BasicInformation { get; set; }
        public List<GoodsDetailsDTO> GoodsDetails { get; set; }
        public List<TaxDetailsDTO> TaxDetails { get; set; }
        public CommonObjectExtraDetailsDTO ExtraDetails { get; set; }
    }

  

  

   
}
