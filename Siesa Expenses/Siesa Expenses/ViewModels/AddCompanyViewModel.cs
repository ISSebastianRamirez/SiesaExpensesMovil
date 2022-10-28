using Siesa_Expenses.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Siesa_Expenses.ViewModels
{
    public class AddCompanyViewModel:BaseCompanyViewModel
    {
        public Command SaveCommand { get; }
        public AddCompanyViewModel()
        {
            SaveCommand = new Command(OnSave);
            companyModel = new CompanyModel();
            this.PropertyChanged += (_,__)=> SaveCommand.ChangeCanExecute();
        }
        private async void OnSave()
        {
            var company = companyModel;
            await App.Comp.AddCompanyAsync(company);
            await Shell.Current.GoToAsync("..");
        }
    }
}
