using SizananiLogistics.Application.Models;

namespace SizananiLogistics.Application
{
    public interface IContractorService
    {
        ContractorResult Get(ContractorRequest request);
        IReadOnlyCollection<ContractorResult> GetAll();
        void Register(RegisterContractorRequest registerRequest);
    }
}
