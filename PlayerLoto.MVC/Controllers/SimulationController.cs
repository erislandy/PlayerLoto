using PlayerLoto.Data;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using PlayerLoto.MVC.Models;
using PlayerLoto.Services.FilterOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace PlayerLoto.MVC.Controllers
{
    public class SimulationController : Controller
    {
        IUnityContainer _container;
        
        public SimulationController(IUnityContainer container)
        {
            _container = container;
        }
        // GET: Simulation
        public ActionResult SimulationView()
        {
            SimulationFilter simulation = new SimulationFilter();
            return View(simulation);
        }

        [HttpPost]
        public ActionResult SimulationView(SimulationFilter simulation)
        {
            if (ModelState.IsValid)
            {
                var repository = _container.Resolve<IRepository>();
                IDrawingResultFilter filter = new DrawingResultFilterByDate(repository, simulation.InitialDate, simulation.FinalDate);
                var drawingResults = filter.Filter();

                var gameManager = _container.Resolve<IGameManager>(simulation.GameOption.ToString());

                foreach (var drawing in drawingResults)
                {
                    gameManager.PlayGame(drawing.Date, drawing.Type);
                    var list = gameManager.GetNumbers().ToList();
                    
                    simulation.MatchGameList.Add(
                        new MatchGame()
                        {
                            DrawingResult = drawing,
                            GameOfday = new GameOfday()
                            {
                                Date = drawing.Date,
                                ArrayPic3 = list,
                                DrawType = drawing.Type
                            },
                            
                        });
                    gameManager.ClearList();
                }
            }
            return View(simulation);
        }
    }
}