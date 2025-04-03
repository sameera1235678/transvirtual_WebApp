using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DijkstraLib.Algorithm;
using DijkstraLib.Data;
using DijkstraLib.Models;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PathFinder _pathFinder;
        private readonly List<Node> _graph;

        public HomeController()
        {
            _pathFinder = new PathFinder();
            _graph = Graph.CreateSampleGraph();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var nodes = new List<string>();

            foreach (var node in _graph)
            {
                nodes.Add(node._name);
            }

            var model = new RouteViewModel { availableNodes = nodes, result = null };
            return View(model);

        }

        [HttpPost]
        public ActionResult Index(RouteViewModel model)
        {
            var nodes = _graph.Select(node => node._name).ToList();
            model.availableNodes = nodes;

            if (ModelState.IsValid)
            {
                try
                {
                    var result = _pathFinder.ShotestPath(model.fromNode, model.toNode, _graph);
                    model.result = result;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error occured", ex.Message);
                }
            }
            else
            {
                model.result = null;
            }

            return View(model);
        }
    }
}