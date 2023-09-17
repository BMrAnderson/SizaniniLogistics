namespace SizananiLogistics.Web.Models
{
    public class ContractorDetailsViewModel
    {
        public required IReadOnlyDictionary<int, string> ContractorsDictionary { get; set; }
        public Contractor? SelectedContractor { get; set; }

        public ContractorDetailsViewModel()
        {
            ContractorsDictionary = new Dictionary<int, string>();
        }
    }
}
