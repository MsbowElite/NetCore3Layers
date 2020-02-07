using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Server.Services;
using Blazor.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace Blazor.Server.Pages
{
    public class CustomerEditBase : ComponentBase
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string CustomerId { get; set; }

        public CustomerDTO Customer { get; set; } = new CustomerDTO();

        //needed to bind to select to value
        protected string CountryId = string.Empty;
        protected string JobCategoryId = string.Empty;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        private IValidator validator;

        private CustomerType _customerType;
        [Required]
        protected CustomerType CustomerType 
        {
            get
            {
                return _customerType;
            }
            set
            {
                _customerType = value;
                var typeInt = (int)_customerType;

                switch (typeInt)
                {
                    case 1:
                        SetupPerson();
                        break;
                    case 2:
                        SetupCompany();
                        break;
                    default:
                        CleanCustomerTypes();
                        break;
                }

                Customer.Type = typeInt;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            Guid.TryParse(CustomerId, out var customerId);

            if (customerId != Guid.Empty) //new Customer is being created
            {
                Customer = await CustomerDataService.GetCustomerDetails(customerId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Customer.Id == Guid.Empty) //new
            {
                var addedCustomer = await CustomerDataService.AddCustomer(Customer);
                if (addedCustomer != Guid.Empty)
                {
                    StatusClass = "alert-success";
                    Message = "New Customer added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new Customer. Please try again.";
                    Saved = false;
                }
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteCustomer()
        {
            await CustomerDataService.DeleteCustomer(Customer.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/customeroverview");
        }

        private void SetupPerson()
        {
            Customer.Person = new CustomerPersonDTO();
            Customer.Company = null;
        }

        private void SetupCompany()
        {
            Customer.Company = new CustomerCompanyDTO();
            Customer.Person = null;
        }

        private void CleanCustomerTypes()
        {
            Customer.Person = null;
            Customer.Company = null;
        }
    }
}
