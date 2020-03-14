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
        public static double ExpenseTotal { get; set; }
        public static double BudgetGoalSetting { get; set; }
        private static Budget budgetGoal = new Budget();
        private static List<Expense> expenses = new List<Expense>();
        
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
    }
}
