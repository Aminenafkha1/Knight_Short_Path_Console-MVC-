using Knight_Short_Path_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;

namespace Knight_Short_Path_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Index(int x, int y)
        {
            Console.WriteLine("x");
            ChessBoard chessBoard = new ChessBoard();
            List<int[]> path = chessBoard.GetShortestPath(x, y );
  
            foreach (var step in path)
            {
                Console.WriteLine("(" + step[0] + ", " + step[1] + ")");
            }
            ViewBag.Result = path;
            return View();
        }

    }
}