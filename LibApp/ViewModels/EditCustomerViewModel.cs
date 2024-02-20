using LibApp.Dtos;

namespace LibApp.ViewModels
{
    public class EditCustomerViewModel
    {
        public CustomerDto Customer { get; set; }
        public IEnumerable<MembershipTypeDto> MembershipTypes { get; set; }
    }
}