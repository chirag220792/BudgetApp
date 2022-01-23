using System;
using System.Collections.Generic;
using System.Linq;
using BudgetApp.Data;
using BudgetApp.Model;

namespace BudgetApp.ViewModel
{
    public class NewIncomeExpenseViewModel:BaseViewModel
    {
        public NewIncomeExpenseViewModel()
        {
            service = new DataService();
            Category = GetBudgets();
        }

        private DataService service;

        public TransactionType TransactionType { get; set; }

        private List<Budget> budget;

        public List<Budget> Category
        {
            get { return budget; }
            set { budget = value; }
        }

        private List<Budget> GetBudgets()
        {
            return service.QueryBudgets(x => x.DateCreated.Month == DateTime.Now.Month || x.Duration == Duration.Monthly).ToList();
        }
    }
}
