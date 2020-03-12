using BudgetPlanning.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetPlanning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseList : ContentPage
    {
        public ExpenseList()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var myexpenses = new List<Expense>();
            var files = Directory.EnumerateFiles(App.FolderPath, "*.expenses.csv");

            foreach (var filename in files)
            {
                string file = File.ReadAllText(filename);
                string[] array = file.Split(',');
                //string[] array = file.Split(new char[] { ',' });

                myexpenses.Add(new Expense
                {
                    Filename = filename,
                    Text = array[0],
                    Date = File.GetCreationTime(filename),
                    Amount = array[1],
                    Category = (ExpenseCategory)Enum.ToObject(typeof(ExpenseCategory), int.Parse(array[2]))
                });
            }
            listView.ItemsSource = myexpenses.OrderByDescending(n => n.Date).ToList();
        }

        private async void OnExpenseAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntry
            {
                BindingContext = new Expense()
            });
        }
        private async void OnListViewItemSelected(object sender,
            SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExpenseEntry
                {
                    BindingContext = e.SelectedItem as Expense
                });
            }
        }
    }
}
