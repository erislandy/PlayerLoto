using PlayerLoto.Data;
using PlayerLoto.Domain;
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
        IRepository _repository;

        public CabalaController(IRepository repository)
        {
            _repository = repository;
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
            bool success = int.TryParse(filter.Word, out number);
            if (success)
            {
                var result = _repository.GetList<Cabala_Number>(c => c.Number == number)
                                           .FirstOrDefault();
                if (result != null)
                {
                    filter.Result = result.Description;
                }
                else
                {
                    filter.Result = "valor no encontrado";
                }
            }

            else
            {
                var result = _repository.GetList<Cabala_Word>(c => c.Word == filter.Word)
                                           .FirstOrDefault();
                if (result != null)
                {
                    filter.Result = result.Numbers;
                }
                else
                {
                    filter.Result = "valor no encontrado";
                }
            }

                
            return View(filter);
        }
    }
}