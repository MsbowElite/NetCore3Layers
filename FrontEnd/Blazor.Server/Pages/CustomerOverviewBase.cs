using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Server.Services;
using Blazor.Shared;
using Microsoft.AspNetCore.Components;

namespace Blazor.Server.Pages
{
    public class CustomerOverviewBase: ComponentBase
    {
        //[Inject]
        //public IHttpClientFactory _clientFactory { get; set; }

        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        public List<CustomerDTO> Customers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customers = (await CustomerDataService.GetAllCustomers()).Data;

            //AddCustomerDialog.OnDialogClose += AddCustomerDialog_OnDialogClose;
        }

        public async void AddCustomerDialog_OnDialogClose()
        {
            Customers = (await CustomerDataService.GetAllCustomers()).Data;
            StateHasChanged();
        }
    }
}
