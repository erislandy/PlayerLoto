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

namespace PlayerLoto.MVC.Controllers
{
    public class DrawingResultsController : Controller
    {
        IRepository _repository;
        ISessionFactory _seccionfactory;
        IDrawingResultManager _drawingResultManager;

        public DrawingResultsController()
        {
            _seccionfactory = new SessionFactory();
            _repository = new Repository(_seccionfactory);
            _drawingResultManager = new DrawingResultManager(_repository);
        }

        // GET: DrawingResults
        public ActionResult Index()
        {
            DrawingResultFilter view = new DrawingResultFilter();
            

            var list  = _repository.GetList<DrawingResult>(
                                                    d => d.Date >= view.InitialDate && 
                                                    d.Date <= view.FinalDate)
                                                    .ToList();


            foreach (var drawing in list)
            {
                view.DrawingResults.Add(drawing);
            }
            return View(view);
        }

        [HttpPost]
        public ActionResult Index(DrawingResultFilter drawing)
        {
            var list = new List<DrawingResult>();
            switch (drawing.DrawingState)
            {
                case DrawingState.All:
                    {
                        list = _repository.GetList<DrawingResult>(
                                                    d => d.Date >= drawing.InitialDate && 
                                                    d.Date <= drawing.FinalDate)
                                                    .ToList();

                        break;
                    }
                case DrawingState.Midday:
                    {
                        list = _repository.GetList<DrawingResult>(
                                                    d => d.Date >= drawing.InitialDate &&
                                                    d.Date <= drawing.FinalDate &&
                                                    d.Type == DrawType.Midday)
                                                    .ToList();
                        break;
                    }
                case DrawingState.Evening:
                    {
                        list = _repository.GetList<DrawingResult>(
                                                    d => d.Date >= drawing.InitialDate &&
                                                    d.Date <= drawing.FinalDate &&
                                                    d.Type == DrawType.Evening)
                                                    .OrderByDescending(d => d.Date)
                                                    .ToList(); break;
                    }
            }

            drawing.DrawingResults.Clear();
            foreach (var view in list)
            {
                drawing.DrawingResults.Add(view);
            }

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
                (_seccionfactory.CurrentUoW.Orm as DbContext).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
