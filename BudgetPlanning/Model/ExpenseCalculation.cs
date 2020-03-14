using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static BudgetPlanning.Model.Expense;
using static BudgetPlanning.Model.Budget;
using static BudgetPlanning.BudgetEntry;
using System.IO;

namespace BudgetPlanning.Model
{
    class ExpenseCalculation
    {
        public static double ExpenseTotal { get; set; }
        public static double BudgetGoalSetting { get; set; }
        private static Budget budgetGoal = new Budget();
        private static List<Expense> expenses = new List<Expense>();
        public string Total { get; set; }
        public string Budget { get; set; }
        public string Balance { get; set; }

        public double GetTotalBudget(string amt)
        {
            budgetGoal.Amount = amt;
            BudgetGoalSetting = double.Parse(amt);
            return BudgetGoalSetting;
        }
        public double GetTotalExpenses(string expense)
        {
            ExpenseTotal += double.Parse(expense);
            return ExpenseTotal;
        }

        public string TotalExpensesCalculation()
        {

            // set up expense
            var files = Directory.EnumerateFiles(App.FolderPath, "*.expenses.csv");
            double ExpenseTotal = 0.00;

            // first time run, expense file doesn't exist yet.
            // run foreach loop only when files exist
            if (files == null || !files.Any())
            {
                Total = "0.00";
            }
            else
            {
                foreach (var filename in files)
                {
                    string file = File.ReadAllText(filename);
                    string[] array = file.Split(',');

                    ExpenseTotal += double.Parse(array[1]);
                }
                Total = ExpenseTotal.ToString();
            }

            return "$" + Total;
        }

        public string BalanceBudget()
        {
            //set up budget
            string filename_budget = Path.GetFileName("*.MonthlyBudget.txt");

            // first time run, budget file doesn't exist yet. Or file is empty
            if (!File.Exists(filename_budget) || File.ReadAllText(filename_budget).Length == 0)
            {
                Budget = "0.00";
            }
            else
            {
                Budget = File.ReadAllText(filename_budget);
            }

            return "$" + Budget;
        }
        public string NewBalanceBudget()
        {
            //balance
            double balance = double.Parse(Budget) - double.Parse(Total);

            //format: -$0.00
            if (balance < 0)
            {
                balance = -balance;
                Balance = balance.ToString();
                return "-$" + Balance;
            }
            else if (balance == 0)
            {
                return "$0.00";
            }
            else
            {
                // format: $0.00
                Balance = balance.ToString();
                return "$" + Balance;
            }
        }
    }
}
