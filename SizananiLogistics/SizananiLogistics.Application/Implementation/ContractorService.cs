using SizananiLogistics.Application.Extensions.Mappers;
using SizananiLogistics.Application.Models;
using SizananiLogistics.Infrastructure;

namespace SizananiLogistics.Application.Implementation
{
    public class ContractorService : IContractorService
    {
        private readonly IContractorRepository _contractor;
        public ContractorService(IContractorRepository contractor)
        {
            _contractor = contractor;
        }

        public ContractorResult Get(ContractorRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var contractor = _contractor.GetById(request.Id);
            
            if (contractor == null)
            {
                throw new InvalidOperationException($"Contractor with Id: [{request.Id}] could not be found. Please try again.");
            }
            
            return contractor.ToResult();
        }

        public IReadOnlyCollection<ContractorResult> GetAll()
        {
            var contractors = _contractor.GetAllContractors(); 
            
            var result = contractors.Select(x => x.ToResult()).ToArray();

            return result;
        }

        public void Register(RegisterContractorRequest registerRequest)
        {
            ArgumentNullException.ThrowIfNull(registerRequest, nameof(registerRequest));

            _contractor.InsertContractor(registerRequest.ToContractor());
        }
    }
}
