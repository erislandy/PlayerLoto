using PlayerLoto.Data;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using PlayerLoto.MVC.Models;
using PlayerLoto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayerLoto.MVC.Controllers
{
    public class AdvancedOperationsController : Controller
    {
        IAdvancedOperation _operation;
        public AdvancedOperationsController(IAdvancedOperation operation)
        {
            _operation = operation;
        }
        
        // GET: AdvancedOperations
        public ActionResult DelayOperation()
        {
            DelayFilter delayFilter = new DelayFilter();
            delayFilter.DelayList = _operation.GetDelays(
                                            delayFilter.InitialDate,
                                            delayFilter.FinalDate, 
                                            delayFilter.DrawType);
            return View(delayFilter);
        }

        [HttpPost]
        public ActionResult DelayOperation(DelayFilter delayFilter)
        {
            delayFilter.DelayList = _operation.GetDelays(
                                           delayFilter.InitialDate,
                                           delayFilter.FinalDate,
                                           delayFilter.DrawType);
            return View(delayFilter);
        }

        public ActionResult DelatedNumbers()
        {
            var delayedNumbers = new DelayedNumbersFilter();
            
            var delayList = new List<Delay>();

            for (int i = 0; i < 100; i++)
            {
                var delay = _operation.GetAmountDayForPick3Tens(i, DateTime.Now, DrawType.Midday);
                delayList.Add(delay);
            }

            delayedNumbers.DelayList = delayList.OrderByDescending(d => d.Days).ToList();
            return View(delayedNumbers);
        }

        [HttpPost]
        public ActionResult DelatedNumbers(DelayedNumbersFilter delayedNumbers)
        {
            var delayList = new List<Delay>();

            for (int i = 0; i < 100; i++)
            {
                var delay = _operation.GetAmountDayForPick3Tens(i, delayedNumbers.Date, delayedNumbers.DrawType);
                delayList.Add(delay);
            }

            delayedNumbers.DelayList = delayList.
                                       Where(f => f.Days >= delayedNumbers.MoreDays &&
                                       f.Days <= delayedNumbers.LessDays)
                                       . OrderByDescending(d => d.Days)
                                       .ToList();
            return View(delayedNumbers);
        }

        [HttpGet]
        public ActionResult PathNumbers()
        {

            return View(new PathNumberFilter());
        }

        [HttpPost]
        public ActionResult PathNumbers(PathNumberFilter pathNumber)
        {
            if (ModelState.IsValid)
            {
                var listInt = new List<int>();
                if (ValidateString(pathNumber.NumberList, listInt))
                {
                    pathNumber.PathList = _operation.GetPath(listInt, pathNumber.InitialDate, pathNumber.FinalDate, pathNumber.DrawType);
                }
            }
            return View(pathNumber);
        }

        private bool ValidateString(string numberList, List<int> listInt)
        {
            var arrayString = numberList.Split(' ');
            foreach (var str in arrayString)
            {
                try
                {

                    var number = int.Parse(str);
                    if(number >= 100)
                    {
                        return false;
                    }
                    listInt.Add(number);

                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }
    }
}