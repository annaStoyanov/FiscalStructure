using Data.DTO;

namespace MAHContracts
{
    public interface ISpecificLogic
    {
        string CountryCode { get; }

        public void Execute(CommonObjectDTO commonObject);
    }
}
