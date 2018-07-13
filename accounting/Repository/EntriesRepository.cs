using System.Collections.Generic;
using System.Linq;
using accounting.Model;
using Microsoft.EntityFrameworkCore;

namespace accounting.Repository
{
    public class EntriesRepository
    {
        public bool AddEntry(Entries entry)
        {
            using(var context = new EFContext())
            {
                var result = context.Add(entry);                
                if(result.State == EntityState.Added)
                {
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool AddEntries(List<Entries> entries)
        {
            using(var context = new EFContext())
            {
                context.AddRange(entries);
                var result = context.SaveChanges();
                if(result == entries.Count)
                {
                    return true;
                }
                return false;
            }
        }

        public bool DeleteEntrie(Entries entry)
        {
            using(var context = new EFContext())
            {
                var result = context.Remove(entry);
                
                if(result.State == EntityState.Deleted)
                {
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateBankAccount(Entries entry)
        {
            using(var context = new EFContext())
            {
                var result = context.Update(entry);
                if(result.State == EntityState.Modified)
                {
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Entries GetEntry(int id)
        {
            using(var context = new EFContext())
            {
                var result = context.Find<Entries>(id);
                context.SaveChanges();
                return result;
            }
        }

        public List<Entries> GetBankAccounts()
        {
            using(var context = new EFContext())
            {
                var result = context.Entries.ToList();
                if(result.Count > 0)
                {
                    return result;
                }
                return new List<Entries>();
            }
        }
    }
}