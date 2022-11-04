using Siesa_Expenses.Models;
using Siesa_Expenses.ViewModels;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Siesa_Expenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public SQLiteConnection _database;
        CompanyViewModel companyViewModel;
        CompanyModel com = new CompanyModel();
        public ObservableCollection<CompanyModel> companyModels { get; }
        public Command GoCompanyTapped { get; }
        public Command LoadCompanyCommand { get; }
        public AboutPage()
        {
            InitializeComponent();
            //BindingContext = companyViewModel = new CompanyViewModel(Navigation);
            //LoadCompanyCommand = new Command(async () => await ExecuteLoadCompanyCommand());
            //var company = com.CompanyName;
            var CompanyList = EjecutarCompany();
            //webView.Source = "https://siesaexpenses.siesacloud.com";
            while (CompanyList.Status != TaskStatus.RanToCompletion)
            {
                CompanyList = EjecutarCompany();
            }
            try
            {
                if (CompanyList.Status != TaskStatus.RanToCompletion)
                {
                    webView.Source = "https://siesaexpenses.siesacloud.com/?cia=";
                }
                else
                {
                    var name = CompanyList.Result.First();
                    webView.Source = "https://siesaexpenses.siesacloud.com/?cia=" + name.CompanyName;
                }
            }
            catch (Exception)
            {
                webView.Source = "https://siesaexpenses.siesacloud.com/?cia=";
            }
            finally
            {

            }
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
                foreach (var com in CompanyList)
                {
                    companyModels.Add(com);
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
        public async Task<IEnumerable<CompanyModel>> EjecutarCompany()
        {
             var company = await App.Comp.GetCompanyAsync();
            return company;
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Charging.IsVisible = false;
            Charging.IsRunning = false;
        }

        private void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Charging.IsVisible = true;
            Charging.IsRunning = true;
        }
        public void OpenViewEvent(CompanyModel company)
        {
            Application.Current.MainPage.Navigation.PushAsync(new CompanyPredeterminada());
        }
    }
}