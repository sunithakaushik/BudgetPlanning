using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static BudgetPlanning.Model.Expense;
using static BudgetPlanning.Model.Budget;
using static BudgetPlanning.BudgetEntry;

namespace BudgetPlanning.Model
{
    class ExpenseCalculation
    {
        private static Budget budgetGoal = new Budget();
        private static List<Expense> expenses = new List<Expense>();
        public static void GetTotalBudget(ObservableCollection<Budget> budgetAmount)
        {            
            double number;
            BudgetEntry goal = new BudgetEntry();
            var amt = budgetGoal.Amount;
            if (Double.TryParse(amt, out number))
            {
                budgetAmount.Add(number);
            }
            
        }
        public static void GetTotalExpenses(ObservableCollection<Expense> expense)
        {            
            double number;
            if (Double.TryParse(expenses.Amount, out number))
                

        }
    }
}
