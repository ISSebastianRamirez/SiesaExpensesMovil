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
    public partial class CompanyWebView : ContentPage
    {
        public CompanyWebView(string UrlCompany)
        {
            InitializeComponent();
            webView.Source = UrlCompany;
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
        public void OpenViewEvent(string company)
        {
            Application.Current.MainPage.Navigation.PushAsync(new CompanyWebView(company));
        }
    }
}