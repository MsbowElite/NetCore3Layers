using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.ComponentsLibrary.Map;
using Blazor.Server.Services;
using Blazor.Shared;
using Microsoft.AspNetCore.Components;

namespace Blazor.Server.Pages
{
    public class CustomerDetailBase : ComponentBase
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Parameter]
        public string CustomerId { get; set; }
       
        public CustomerDTO Customer { get; set; } = new CustomerDTO();

        protected override async Task OnInitializedAsync()
        {
            Customer = await CustomerDataService.GetCustomerDetails(new System.Guid(CustomerId));
        }
    }
}
