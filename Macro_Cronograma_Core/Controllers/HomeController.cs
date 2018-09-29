using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Macro_Cronograma_Core.Models;
using Macro_Cronograma.services;
using Macro_Cronograma.models;

namespace Macro_Cronograma_Core.Controllers
{
    public class HomeController : Controller
    {
        macro_cronogramaContext db = new macro_cronogramaContext();

        public IActionResult Index()
        {
            return View(db.tb_projeto);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
