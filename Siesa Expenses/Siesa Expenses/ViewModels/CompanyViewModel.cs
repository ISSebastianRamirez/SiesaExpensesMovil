using Siesa_Expenses.Models;
using Siesa_Expenses.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Siesa_Expenses.ViewModels
{
    public class CompanyViewModel : BaseCompanyViewModel
    {
        
        PredeterminadaModel _predeterminadaModel;
        public Command LoadCompanyCommand { get; }
        public ObservableCollection<CompanyModel> companyModels { get; }
        public Command AddCompanyCommand { get; }
        public Command CompanyTappedEdit { get; }
        public Command CompanyTappedDelete { get; }
        public Command GoCompanyTapped { get; }
        public CompanyViewModel(INavigation _nav)
        {
            LoadCompanyCommand = new Command(async () => await ExecuteLoadCompanyCommand());
            companyModels = new ObservableCollection<CompanyModel>();
            AddCompanyCommand = new Command(OnAddCompany);
            CompanyTappedEdit = new Command<CompanyModel>(OnEditCompany);
            CompanyTappedDelete = new Command<CompanyModel>(OnDeleteCompany);
            GoCompanyTapped = new Command<CompanyModel>(OnGoCompany);

            Navigation = _nav;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
        async Task ExecuteLoadCompanyCommand()
        {
            IsBusy = true;
            try
            {
                companyModels.Clear();
                var CompanyList = await App.Comp.GetCompanyAsync();
                foreach (var list in CompanyList)
                {
                    companyModels.Add(list);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void OnAddCompany(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddCompanyPage));
        }
        private async void OnEditCompany(CompanyModel com)
        {
            //await Shell.Current.GoToAsync(nameof(AddCompanyPage));
            await Navigation.PushAsync(new AddCompanyPage(com));
        }
        private async void OnDeleteCompany(CompanyModel com)
        {
            //await Shell.Current.GoToAsync(nameof(AddCompanyPage));
            await App.Comp.DeleteCompanyAsync(com.CompanyId);
            await ExecuteLoadCompanyCommand();
        }
        private async void OnGoCompany(CompanyModel com)
        {
            var company = com.CompanyName;
            string url = "https://siesaexpenses.siesacloud.com/?cia=" + company;
            await Navigation.PushAsync(new CompanyWebView(url));
        }
    }
}
