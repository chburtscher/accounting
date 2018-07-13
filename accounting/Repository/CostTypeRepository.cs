using System.Collections.Generic;
using System.Linq;
using accounting.Model;
using Microsoft.EntityFrameworkCore;

namespace accounting.Repository 
{
    public class CostTypeRepository
     {
        public int AddCostType (CostType costType) {
            int result;

            using (var context = new EFContext ()) {

                context.Add (costType);
                result = context.SaveChanges ();
            }

            if (result > 0) {
                return costType.Id;
            }

            return 0;
        }

        public bool DeleteCostType (CostType costType) 
        {
            using (var context = new EFContext ()) 
            {
                var result = context.Remove<CostType> (costType);
                
                if (result.State == EntityState.Deleted)
                {
                    context.SaveChanges ();
                    return true;
                }
                return false;
            }
        }

        public CostType GetCostType (int id) 
        {
            using (var context = new EFContext ()) 
            {
                var result = context.Find<CostType> (id);
                context.SaveChanges();
                return result;
            }
        }

        public List<CostType> GetCostTypes ()
         {
            using (var context = new EFContext ()) 
            {
                var result = context.CostTypes.ToList ();
                if (result.Count > 0) {
                    return result;
                }
                return new List<CostType>();
            }
        }

        public bool UpdateCostType (CostType costType)
         {
            using (var context = new EFContext ()) 
            {
                var result = context.Update (costType);
                if (result.State == EntityState.Modified) 
                {
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}