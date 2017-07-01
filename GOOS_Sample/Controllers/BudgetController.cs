using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.DataModels;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetService _budgetService;
        public BudgetController(IBudgetService budgetService)
        {
            this._budgetService = budgetService;
        }
   
        // GET: Budget
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            this._budgetService.Create(model);
            ViewBag.Message = "added successfully";
            return View(model);
        }

    }

    public class BudgetService : IBudgetService
    { 
        private IRepository<Budget> _budgetRepository;
        public BudgetService(IRepository<Budget> budgetRepository)
        {
            this._budgetRepository = budgetRepository;
        }

        public void Create(BudgetAddViewModel model)
        {
            var budget = new Budget() { Amount = model.Amount, YearMonth = model.Month };
            this._budgetRepository.Save(budget);
        }
    }
}