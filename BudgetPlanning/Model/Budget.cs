using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanning.Model
{
    public class Budget
    {
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public string Filename { get; set; }

        public Budget()
        { }
        public Budget(string goal)
        {
            Amount = goal;
        }
    }
}
