using Macro_Cronograma.models;
using System.Collections.Generic;
using System.Linq;

namespace Macro_Cronograma.DAO
{
    class projetoDAO 
    {
        public void Gravar(tb_projeto projeto)
        {
            using (var db = new macro_cronogramaContext())
            {
                var proj = new tb_projeto()
                {
                    id_projeto = projeto.id_projeto,
                    des_projeto = projeto.des_projeto,
                    dt_inicio = projeto.dt_inicio,
                    dt_fim = projeto.dt_fim
                };

                db.tb_projeto.Add(proj);
                db.SaveChanges();
            }
        }

        public void Excluir(int idProjeto)
        {
            using (var db = new macro_cronogramaContext())
            {
                var projeto = from a in db.tb_projeto where a.id_projeto == idProjeto select a;

                db.tb_projeto.Remove(projeto.FirstOrDefault());
                db.SaveChanges();
            }
        }

        public List<tb_projeto> Listar()
        {
            using(var db = new macro_cronogramaContext())
            {
               var queryProjetos = (from p in db.tb_projeto
                                     select new tb_projeto()
                                     {
                                         id_projeto = p.id_projeto,
                                         des_projeto = p.des_projeto,
                                         dt_inicio = p.dt_inicio,
                                         dt_fim = p.dt_fim
                                     }).ToList();

                return queryProjetos;
            }
        }

        public void Atualizar(tb_projeto projeto)
        {
            using(var db = new macro_cronogramaContext())
            {
                var proj = (from p in db.tb_projeto where p.id_projeto.Equals(projeto.id_projeto) select p).FirstOrDefault();

                proj.des_projeto = projeto.des_projeto;
                proj.dt_inicio = projeto.dt_inicio;
                proj.dt_fim = projeto.dt_fim;

                db.tb_projeto.Add(proj);
                db.SaveChanges();
            }
        }
    }
}
