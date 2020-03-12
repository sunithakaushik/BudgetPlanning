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
    public partial class ExpenseEntry : ContentPage
    {

        private List<string> categories;
        public ExpenseEntry()
        {
            InitializeComponent();

            BindingContext = new Expense();

            categories = new List<string>();
            foreach (string name in Enum.GetNames(typeof(ExpenseCategory)))
            {
                categories.Add(name.ToString());
            }

            CategoryPicker.ItemsSource = categories;
        }
     /*   private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateLabel.Text = e.NewDate.ToString();
        }*/
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            var filename = Path.Combine(App.FolderPath,
                            $"{Path.GetRandomFileName()}.expenses.csv");

            StringBuilder stringBuilder = new StringBuilder();

            string category = string.Empty;

            if (CategoryPicker.SelectedIndex >= 0)
            {
                category = CategoryPicker.SelectedIndex.ToString();
            }

            stringBuilder.Append(expense.Text + ",");
            stringBuilder.Append(expense.Amount + ",");
            //stringBuilder.Append(expense.Category);
            stringBuilder.Append(category);

            if (string.IsNullOrEmpty(expense.Filename))
            {
                File.WriteAllText(filename, stringBuilder.ToString());
            }
            else
            {
                File.WriteAllText(expense.Filename, stringBuilder.ToString());
            }

            await Navigation.PushAsync(new ExpenseList());

        }
        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (expense == null)
                return;
            if (File.Exists(expense.Filename))
            {
                File.Delete(expense.Filename);
            }
            await Navigation.PopAsync();
        }

    }
}