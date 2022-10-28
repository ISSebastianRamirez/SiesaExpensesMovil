using Siesa_Expenses.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Siesa_Expenses.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}