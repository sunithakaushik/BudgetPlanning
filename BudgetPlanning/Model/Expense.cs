using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanning.Model
{
    public class Expense
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public Expense(string spent)
        {
            Amount = spent;
        }
    }
    
    
    public enum ExpenseCategory

    {
        Home,
        Groceries,
        Entertainment,
        Food,
        Charity,
        Utilities,
        Auto,
        Education,
        HealthAndWellness,
        Shopping,
        Medical,
        DayCare,
        Saving,
        Holiday,
        Gifts,
        Travel,
        Miscellaneous
    };

     /*public class Category
     {
         public string CategoryType { get; set; }

         public Category(string type)
         {
             CategoryType = type;
         }

        public void addCategory (string type)
        {
            var categories = new List<Category>();
            categories.Add(new Category(type));
        }
     }*/
}
