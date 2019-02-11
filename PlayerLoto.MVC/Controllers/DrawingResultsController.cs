using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlayerLoto.Data;
using PlayerLoto.DataEF;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using PlayerLoto.MVC.Models;
using PlayerLoto.Services;
using PlayerLoto.Services.FilterOperation;

namespace PlayerLoto.MVC.Controllers
{
    public class DrawingResultsController : Controller
    {
        IRepository _repository;
        //IDrawingResultManager _drawingResultManager;

        public DrawingResultsController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult WeekResult()
        {
            WeekResultFilter weekFilter = new WeekResultFilter();
           
            DrawingState state = (DrawingState)Enum.Parse(typeof(DrawingState), weekFilter.DrawType.ToString());
            IDrawingResultFilter filterByDate = new DrawingResultFilterByDate(_repository, weekFilter.InitialDate, weekFilter.FinalDate);
            IDrawingResultFilter filter = new DrawingResultFilterByType(filterByDate, state);
            var list = filter.Filter();

            
            WeekResultManager manager = new WeekResultManager();
            weekFilter.WeekResultList = manager.CreateWeekResult(list);
            return View(weekFilter);
        }

        [HttpPost]
        public ActionResult WeekResult(WeekResultFilter weekFilter)
        {
            if (!ModelState.IsValid)
            {
                return View(weekFilter);
            }
            DrawingState state = (DrawingState)Enum.Parse(typeof(DrawingState), weekFilter.DrawType.ToString());
            IDrawingResultFilter filterByDate = new DrawingResultFilterByDate(_repository, weekFilter.InitialDate, weekFilter.FinalDate);
            IDrawingResultFilter filter = new DrawingResultFilterByType(filterByDate, state);
            var list = filter.Filter();


            WeekResultManager manager = new WeekResultManager();
            weekFilter.WeekResultList = manager.CreateWeekResult(list);
            return View(weekFilter);

        }
        // GET: DrawingResults
        public ActionResult Index()
        {
            DrawingResultFilter view = new DrawingResultFilter();

            IDrawingResultFilter filter = new DrawingResultFilterByDate(_repository, view.InitialDate, view.FinalDate);
            view.DrawingResults = filter.Filter();

            return View(view);
        }

        [HttpPost]
        public ActionResult Index(DrawingResultFilter drawing)
        {
            IDrawingResultFilter filter = new DrawingResultFilterByDate(
                                                            _repository,
                                                            drawing.InitialDate, drawing.FinalDate);
            var filterParameter = new DrawingResultFilterByParameter(filter, drawing.Parameter, drawing.ParameterType);

            var filterType = new DrawingResultFilterByType(filterParameter, drawing.DrawingState);

            drawing.DrawingResults = filterType.Filter();

            return View(drawing);
        }


        // GET: DrawingResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingResult drawingResult = _repository.GetEntity<DrawingResult>(id);
            if (drawingResult == null)
            {
                return HttpNotFound();
            }
            return View(drawingResult);
        }

        // GET: DrawingResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrawingResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DrawingResult drawingResult)
        {
            if (ModelState.IsValid)
            {
                _repository.AddEntity<DrawingResult>(drawingResult);
                return RedirectToAction("Index");
            }

            return View(drawingResult);
        }

        // GET: DrawingResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingResult drawingResult = _repository.GetEntity<DrawingResult>(id);
            if (drawingResult == null)
            {
                return HttpNotFound();
            }
            return View(drawingResult);
        }

        // POST: DrawingResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DrawingResult drawingResult)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateEntity<DrawingResult>(drawingResult);
                return RedirectToAction("Index");
            }
            return View(drawingResult);
        }

        // GET: DrawingResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingResult drawingResult = _repository.GetEntity<DrawingResult>(id);
            if (drawingResult == null)
            {
                return HttpNotFound();
            }
            return View(drawingResult);
        }

        // POST: DrawingResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrawingResult drawingResult = _repository.GetEntity<DrawingResult>(id);
            _repository.DeleteEntity<DrawingResult>(drawingResult);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                (_repository.UoW.Orm as DbContext).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
