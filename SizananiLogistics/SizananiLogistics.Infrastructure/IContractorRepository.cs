using SizananiLogistics.Infrastructure.Models;

namespace SizananiLogistics.Infrastructure
{
    public interface IContractorRepository
    {
        Contractor? GetById(int id);
        Contractor[] GetAllContractors();
        void InsertContractor(Contractor contractor);
    }
}
