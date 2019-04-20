using PlayerLoto.Data;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using PlayerLoto.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayerLoto.MVC.Controllers
{
    public class CabalaController : Controller
    {
        ICabalaManager _manager;

        public CabalaController(ICabalaManager manager)
        {
            _manager = manager;
        }
        // GET: Cabala
        public ActionResult Index()
        {
            var filter = new CabalaFilter();
            return View(filter);
        }
        [HttpPost]
        public ActionResult Index(CabalaFilter filter)
        {
            int number;
            filter.Cabala_Words = new List<Cabala_Word>();
            filter.CabalaNumber = null;
            bool success = int.TryParse(filter.Word, out number);
            if (success)
            {
                filter.CabalaNumber = _manager.FindByNumber(number);
            }

            else
            {
                filter.Cabala_Words = _manager.FindbyWord(filter.Word);
               
            }

                
            return View(filter);
        }
    }
}