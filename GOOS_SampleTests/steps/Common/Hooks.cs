﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation;
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

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
