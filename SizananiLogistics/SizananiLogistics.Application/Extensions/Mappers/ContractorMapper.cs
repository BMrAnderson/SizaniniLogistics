using SizananiLogistics.Application.Models;
using Contractor = SizananiLogistics.Infrastructure.Models.Contractor;

namespace SizananiLogistics.Application.Extensions.Mappers
{
    public static class ContractorMapper
    {
        public static ContractorResult ToResult(this Contractor contractor)
        {
            var result = new ContractorResult()
            {
                Id = contractor.Id,
                EmailAddress = contractor.EmailAddress,
                Name = contractor.Name,
                PhoneNumber = contractor.PhoneNumber,
            };
            return result;
        }

        public static Contractor ToContractor(this RegisterContractorRequest request)
        {
            var contractor = new Contractor()
            {
                Id = 0,
                EmailAddress = request.Contractor.EmailAddress,
                Name = request.Contractor.Name,
                PhoneNumber = request.Contractor.PhoneNumber
            };
            return contractor;
        }
    }
}
