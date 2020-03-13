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
    public partial class BudgetEntry : ContentPage
    {
        private string filename;

        public BudgetEntry()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var files = Directory.GetFiles(App.FolderPath, "*.MonthlyBudget.txt");
            if (files.Length != 0)
            {
                filename = files[0];
                string budget = File.ReadAllText(filename);
                editor.Text = budget;
        //        Navigation.PushAsync(new ExpenseList());
            }
            else
            {
                editor.Text = string.Empty;
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Budget budget = new Budget();
            if (string.IsNullOrWhiteSpace(budget.Filename))
            {
                filename = Path.Combine(App.FolderPath,
                    $"{Path.GetRandomFileName()}.MonthlyBudget.txt");
                budget.Filename = filename;
                budget.Amount = editor.Text;
                File.WriteAllText(filename, editor.Text);
            }
            else
            {
                budget.Amount = editor.Text;
                File.WriteAllText(budget.Filename, editor.Text);
            }
        //    await Navigation.PopAsync();
            await Navigation.PushAsync(new ExpenseList());
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            editor.Text = string.Empty;
            await Navigation.PopAsync();
        }
        /*  private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
          {
              if (e.SelectedItem != null)
              {
                  await Navigation.PushAsync(new ExpenseList
                  {
                      BindingContext = e.SelectedItem as Expense
                  });
              }
          }*/
        /*private void DatePicker_DateSelected_1(object sender, DateChangedEventArgs e)
        {
            DateLabel.Text = e.NewDate.ToString();
        }*/
    }
}