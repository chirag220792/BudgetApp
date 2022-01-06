using System;
using System.Collections.Generic;
using BudgetApp.Model;
using Xamarin.Forms;

namespace BudgetApp.View
{
    public partial class IncomeExpensePage : ContentPage
    {
        public IncomeExpensePage(TransactionType transactionType)
        {
            InitializeComponent();
            _transactionType = transactionType;
            Init(_transactionType);
        }

        private TransactionType _transactionType;

        private void Init(TransactionType type)
        {
            TitleTxt.Text = type == TransactionType.Expense ? "EXPENSE" : "INCOME";
            
        }

        void AddTapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewIncomeExpensePage(_transactionType), true);
        }
    }
}
