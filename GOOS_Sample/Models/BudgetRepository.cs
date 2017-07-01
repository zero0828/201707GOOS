using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOOS_Sample.DataModels;

namespace GOOS_Sample.Models
{

    public class BudgetRepository : IRepository<Budget>
    {
        public void Save(Budget budget)
        {
            using (var dbcontext = new NORTHWNDEntities())
            {
             //   var budget = new Budget() { Amount = model.Amount, YearMonth = model.Month };
                dbcontext.Budgets.Add(budget);
                dbcontext.SaveChanges();
            }
        }
    }
}
