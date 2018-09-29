using Macro_Cronograma.models;
using System.Collections.Generic;
using System.Linq;

namespace Macro_Cronograma.DAO
{
    public class atividadeDAO
    {
        public void Gravar(tb_atividade atividade)
        {
            using(var db = new macro_cronogramaContext())
            {
                var atv = new tb_atividade()
                {
                    des_atividade = atividade.des_atividade,
                    flag_deadline = atividade.flag_deadline,
                    dt_inicio = atividade.dt_inicio,
                    dt_fim = atividade.dt_fim,
                    cod_cor_grafico = atividade.cod_cor_grafico,
                    id_projeto = atividade.id_projeto
                };

                db.tb_atividade.Add(atv);
                db.SaveChanges();
            }
        }

        public void Excluir(int idAtividade)
        {
            using (var db = new macro_cronogramaContext())
            {
                var atividade = from a in db.tb_atividade where a.id_atividade == idAtividade select a;

                db.tb_atividade.Remove(atividade.FirstOrDefault());
                db.SaveChanges();
            }
        }
        public List<tb_atividade> Listar()
        {
            using (var db = new macro_cronogramaContext())
            {
                var queryAtividades = (from a in db.tb_atividade
                                     select new tb_atividade()
                                     {
                                         id_atividade = a.id_atividade,
                                         des_atividade = a.des_atividade,
                                         flag_deadline = a.flag_deadline,
                                         dt_inicio = a.dt_inicio,
                                         dt_fim = a.dt_fim,
                                         cod_cor_grafico = a.cod_cor_grafico
                                     }).ToList();

                return queryAtividades;
            }
        }

        public void Atualizar(tb_atividade atividade)
        {
            using (var db = new macro_cronogramaContext())
            {
                var atv = (from a in db.tb_atividade where a.id_atividade.Equals(atividade.id_projeto) select a).FirstOrDefault();

                atv.des_atividade = atividade.des_atividade;
                atv.flag_deadline = atividade.flag_deadline;
                atv.dt_inicio = atividade.dt_inicio;
                atv.dt_fim = atividade.dt_fim;
                atv.cod_cor_grafico = atividade.cod_cor_grafico;

                db.tb_atividade.Add(atv);
                db.SaveChanges();

            }
        }

    }
}
