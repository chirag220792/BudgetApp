using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class DataService
    {
        private readonly AppDbContext context;

        public DataService()
        {
            context = new AppDbContext();
        }

        //Add Transaction
        //Update Transaction
        //Delete Transaction
        //Get All Transaction
        //Get Single Transaction by ID
        //Query Transactions

        //Add Budget
        //Update Budget
        //Delete Budget
        //Get All Budget
        //Get Single Budget by ID
        //Query Budget


        //Section for Transaction Data Service
        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            try
            {
                var result = await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                return result.State == EntityState.Added;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTransaction(Transaction transaction)
        {
            try
            {
                var result = context.Transactions.Update(transaction);
                await context.SaveChangesAsync();

                return result.State == EntityState.Modified;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTransaction(Transaction transaction)
        {
            try
            {
                var result = context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();

                return result.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            try
            {
                var result = await context.Transactions.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            try
            {
                var result = await context.Transactions.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Transaction> QueryTransactions(Func<Transaction, bool> predicate)
        {
            try
            {
                var result = context.Transactions.Where(predicate);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


        //Section for Budget Data Service
        public async Task<bool> AddBudgetAsync(Budget budget)
        {
            try
            {
                var result = await context.Budgets.AddAsync(budget);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBudgetAsync(Budget budget)
        {
            try
            {
                var result = context.Budgets.Update(budget);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBudgetAsync(Budget budget)
        {
            try
            {
                var result = context.Budgets.Remove(budget);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Budget>> GetBudgetsAsync()
        {
            try
            {
                var result = await context.Budgets.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Budget> GetBudgetByIdAsync(int id)
        {
            try
            {
                var result = await context.Budgets.FindAsync(id);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Budget> QueryBudgets(Func<Budget, bool> predicate)
        {
            try
            {
                var result = context.Budgets.Where(predicate);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
