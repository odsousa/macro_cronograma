using Macro_Cronograma.models;
using System.Collections.Generic;
using System.Linq;

namespace Macro_Cronograma.DAO
{
    public class atribuicaoDAO
    {
        public void Gravar(tb_atribuicao atribuicao)
        {
            using (var db = new macro_cronogramaContext())
            {
                var atb = new tb_atribuicao()
                {
                    id_atribuicao = atribuicao.id_atribuicao,
                    des_atribuicao = atribuicao.des_atribuicao,
                    cod_cor_grafico = atribuicao.cod_cor_grafico
                };

                db.tb_atribuicao.Add(atb);
                db.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var db = new macro_cronogramaContext())
            {
                var atribuicao = from a in db.tb_atribuicao where a.id_atribuicao == id select a;

                db.tb_atribuicao.Remove(atribuicao.FirstOrDefault());
                db.SaveChanges();
            }
        }

        public List<tb_atribuicao> Listar()
        {
            using (var db = new macro_cronogramaContext())
            {
                var queryString = (from a in db.tb_atribuicao
                                   select new tb_atribuicao()
                                   {
                                       id_atribuicao = a.id_atribuicao,
                                       des_atribuicao = a.des_atribuicao,
                                       cod_cor_grafico =  a.cod_cor_grafico
                                       
                                   }).ToList();

                return queryString;
            }

        }

        public void Atualizar(tb_atribuicao atribuicao)
        {
            using (var db = new macro_cronogramaContext())
            {
                var atb = (from a in db.tb_atribuicao where a.id_atribuicao == atribuicao.id_atribuicao select a).FirstOrDefault();

                atb.des_atribuicao = atribuicao.des_atribuicao;
                atb.cod_cor_grafico = atribuicao.cod_cor_grafico;

                db.tb_atribuicao.Add(atb);
                db.SaveChanges();
            }          
        }
    }

}
