using Siesa_Expenses.Models;
using Siesa_Expenses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Siesa_Expenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCompanyPage : ContentPage
    {
        public CompanyModel companyModel { get; set; }
        public AddCompanyPage()
        {
            InitializeComponent();
            BindingContext = new AddCompanyViewModel();
        }
        public AddCompanyPage(CompanyModel com)
        {
            InitializeComponent();
            BindingContext = new AddCompanyViewModel();
            if (com!=null)
            {
                ((AddCompanyViewModel)BindingContext).companyModel = com;
            }
        }
    }
}