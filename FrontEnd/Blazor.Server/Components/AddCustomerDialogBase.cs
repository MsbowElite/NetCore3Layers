using System;
using System.Threading.Tasks;
using Blazor.Server.Services;
using Blazor.Shared;
using Microsoft.AspNetCore.Components;

namespace Blazor.Server.Components
{
    public class AddCustomerDialogBase : ComponentBase
    {
        public bool ShowDialog { get; set; }

        public CustomerDTO Customer { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject] 
        public ICustomerDataService CustomerDataService { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            await CustomerDataService.AddCustomer(Customer);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
