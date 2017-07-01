using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;
using GOOS_SampleTests.Controllers;
using GOOS_SampleTests.DataModelsForIntegrationTest;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
 

namespace GOOS_SampleTests.steps
{
    public class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        public BudgetCreatePage(FluentTest test): base(test)
        {
            //this.Url = $"{PageContext.Domain}/budget/add";
            this.Url = PageContext.Domain +"/budget/add";
        }

        public BudgetCreatePage Amount(int amount)
        { 
            I.Enter(amount.ToString()).In("#amount");
            return this;
        }

        public BudgetCreatePage Month(string yearMonth)
        {
            I.Enter(yearMonth).In("#month");
            return this;
        }

        public BudgetCreatePage AddBudget()
        {
            I.Click("input[type=\"submit\"]");
            return this;
        }

        public BudgetCreatePage ShouldDisplay(string message)
        {
            I.Assert.Text(message).In("#message");
            return this;
        } 

    }
}
