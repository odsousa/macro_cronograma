using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Macro_Cronograma.models;
using Macro_Cronograma.services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Macro_Cronograma_Core.Controllers
{
    public class ProjetoController : Controller
    {
        private macro_cronogramaContext db = new macro_cronogramaContext();
        private projeto projetoService = new projeto();
        
        // GET: /<controller>/
        public IActionResult Projeto()
        {
            return View(db.tb_projeto);
        }

        public IActionResult Tables()
        {
            var projeto = db.tb_projeto.ToList();
            return View(projeto);
        }
    }
}
