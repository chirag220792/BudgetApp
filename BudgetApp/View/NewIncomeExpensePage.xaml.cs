using System;
using System.Collections.Generic;
using BudgetApp.Model;
using Xamarin.Forms;

namespace BudgetApp.View
{
    public partial class NewIncomeExpensePage : ContentPage
    {
        public NewIncomeExpensePage()
        {
            InitializeComponent();
        }

        public NewIncomeExpensePage(TransactionType type)
        {
            InitializeComponent();
            _type = type;
        }

        private TransactionType _type;
    }
}
