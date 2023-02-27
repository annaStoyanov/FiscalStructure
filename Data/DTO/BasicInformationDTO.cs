using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class BasicInformationDTO
    {
        public string Operator { get; set; }
        public string InvoiceType { get; set; }
        public string Country { get; set; }
        public string DocumentNumber { get; set; }
        public string MChoiceDocType { get; set; }
        public string CustomerName { get; set; }
        public string CountryCode { get; set; }
        public string TestNotInModel { get; set; }
        public decimal AccountNumber { get; set; }
        public int CompanyCode { get; set; }

        public decimal Tax { get; set; }

        public BasicInformationExtraDetails ExtraDetails { get; set; }
    }
}
