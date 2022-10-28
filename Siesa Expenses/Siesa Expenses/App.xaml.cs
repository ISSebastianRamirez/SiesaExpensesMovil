using Siesa_Expenses.Services;
using Siesa_Expenses.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Siesa_Expenses
{
    public partial class App : Application
    {
        static CompanyService _comp;
        public static CompanyService Comp
        {
            get
            {
                if (_comp == null)
                {
                    _comp = new CompanyService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SiesaExpenses.db3"));
                }
                return _comp;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
