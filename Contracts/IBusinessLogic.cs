using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBusinessLogic
    {
        public string CountryCode { get; set; }

        public Task PopulateFieldsAsync(GeneralObject generalObejct);
    }
}
