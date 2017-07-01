using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;

namespace GOOS_SampleTests.steps
{
    public class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        public BudgetCreatePage(FluentTest test)
            : base(test)
        {
        }

        public BudgetCreatePage Amount(int amount)
        {
            throw new NotImplementedException();
        }

        public BudgetCreatePage Month(string yearMonth)
        {
            throw new NotImplementedException();
        }

        public BudgetCreatePage AddBudget()
        {
            throw new NotImplementedException();
        }

        public BudgetCreatePage ShouldDisplay(string message)
        {
            throw new NotImplementedException();
        }
    }
}
