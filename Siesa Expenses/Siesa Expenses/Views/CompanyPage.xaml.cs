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
    public partial class CompanyPage : ContentPage
    {   
        CompanyViewModel companyViewModel;
        public CompanyPage()
        {
            InitializeComponent();
            BindingContext = companyViewModel = new CompanyViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            companyViewModel.OnAppearing();
        }
    }
}