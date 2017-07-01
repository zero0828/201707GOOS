using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;
using GOOS_Sample.Controllers;
using GOOS_Sample.DataModels;
using GOOS_Sample.Models;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [Scope(Tag = "web")]
        [BeforeScenario]
        public void SetBrowser()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [BeforeScenario()]
        public void BeforeScenarioCleanTable()
        {
            CleanTableByTags();
        }

        [AfterFeature()]
        public static void AfterFeatureCleanTable()
        {
            CleanTableByTags();
        }
         
        public static void CleanTableByTags()
        { 
            var tags = ScenarioContext.Current.ScenarioInfo.Tags
                .Where(x => x.StartsWith("Clean"))
                .Select(x => x.Replace("Clean", ""));

            if (!tags.Any())
            {
                return;
            }
            using (var dbcontext = new NORTHWNDEntities())
            {
                foreach (var tag in tags)
                {
                    dbcontext.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + tag + "]");
                }
                dbcontext.SaveChangesAsync();
            }
        }
 
        public static IUnityContainer UnityContainer
        {
            get;
            set;
        }

        [BeforeTestRun()]
        public static void RegisterDIContainer()
        {
            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<IRepository<Budget>, BudgetRepository>();
            UnityContainer.RegisterType<IBudgetService, BudgetService>();
        }

    }
}
