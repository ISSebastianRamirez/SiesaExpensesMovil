using Siesa_Expenses.Models;
using Siesa_Expenses.Services;
using Siesa_Expenses.ViewModels;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;

namespace Siesa_Expenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyPredeterminada : ContentPage
    {
        CompanyViewModel viewModel;
        string namecompany = string.Empty;
        CompanyModel listcom = new CompanyModel();
        public CompanyPredeterminada()
        {
            InitializeComponent();
            viewModel.companyModels.Clear();
            var CompanyList =  App.Comp.GetCompanyAsync();
            while (CompanyList.Status != TaskStatus.RanToCompletion)
            {
                CompanyList = App.Comp.GetCompanyAsync();
            }
            var name = CompanyList.Result.First();
            webView.Source = "https://siesaexpenses.siesacloud.com/?cia=" + name.CompanyName;
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