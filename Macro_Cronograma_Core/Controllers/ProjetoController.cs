using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Macro_Cronograma.models;
using Macro_Cronograma.services;
using Macro_Cronograma_Core.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Macro_Cronograma_Core.Controllers
{
    public class ProjetoController : Controller
    {
        private macro_cronogramaContext db = new macro_cronogramaContext();
        private projeto projetoService = new projeto();
        private atividade atividadeService = new atividade();
        
        // GET: /<controller>/
        public IActionResult Projeto(int id)
        {
            ViewBag.ProjetoSelecionado 
                = projetoService.buscarProjeto(id);

            ViewBag.atividades =
                atividadeService.listarAtividadesProjeto(id);

            return View(db.tb_projeto);
        }

        public IActionResult Tables()
        {
            var projeto = db.tb_projeto.ToList();
            return View(projeto);
        }

        public JsonResult PopularGraficos(int idProjeto)
        {
            var populationList = atividadeService.listarAtividadesProjeto(idProjeto);
            return Json(populationList);
        }
    }
}
