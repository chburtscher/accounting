using System.Collections.Generic;
using System.Linq;
using accounting.Model;
using Microsoft.EntityFrameworkCore;

namespace accounting.Repository
{
    public class BankAccountRepository
    {
        public bool AddBankAccount(BankAccount bankAccount)
        {
            using(var context = new EFContext())
            {
                var result = context.Add(bankAccount);                
                if(result.State == EntityState.Added)
                {
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteBankAccount(BankAccount bankAccount)
        {
            using(var context = new EFContext())
            {
                var result = context.Remove(bankAccount);
                
                if(result.State == EntityState.Deleted)
                {
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateBankAccount(BankAccount bankAccount)
        {
            using(var context = new EFContext())
            {
                var result = context.Update(bankAccount);
                if(result.State == EntityState.Modified)
                {
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public BankAccount GetBankAccount(int id)
        {
            using(var context = new EFContext())
            {
                var result = context.Find<BankAccount>(id);
                context.SaveChanges();
                return result;
            }
        }

        public List<BankAccount> GetBankAccounts()
        {
            using(var context = new EFContext())
            {
                var result = context.BankAccounts.ToList();
                if(result.Count > 0)
                {
                    return result;
                }
                return new List<BankAccount>();
            }
        }
    }
}