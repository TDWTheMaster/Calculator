using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using tarea6.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculator(double input1, double input2, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = input1 + input2;
                    break;
                case "-":
                    result = input1 - input2;
                    break;
                case "*":
                    result = input1 * input2;
                    break;
                case "/":
                    if (input2 != 0)
                        result = input1 / input2;
                    else
                        ViewBag.ErrorMessage = "Cannot divide by zero!";
                    break;
                case "^": // Manejo de la operación de elevado
                    result = Math.Pow(input1, input2);
                    break;
                case "sqrt": // Manejo de la operación de raíz cuadrada
                    result = Math.Sqrt(input1);
                    break;
                default:
                    ViewBag.ErrorMessage = "Invalid operation!";
                    break;
            }
            ViewBag.Result = result;
            return PartialView("_CalculatorResult");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
