using System.Collections.Generic;
using Macro_Cronograma.models;
using Macro_Cronograma.DAO;
using System.Linq;

namespace Macro_Cronograma.services
{
    public class atividade
    {
        public tb_atividade atividadeModel { get; set; }
        public atividadeDAO atividadeDAO { get; set; }

        public tb_projeto projetoModel { get; set; }
        public projetoDAO projetoDAO { get; set; }

        public tb_atribuicao atribuicaoModel { get; set; }
        public atribuicaoDAO atribuicaoDAO { get; set; }


        public void gravarAtividade(tb_atividade atividade)
        {
            atividade.cod_cor_grafico = atribuicaoDAO.Listar()
                .Where(a => a.des_atribuicao.Equals(atividade.cod_cor_grafico)).First().ToString();

            var projeto = projetoDAO.Listar()
                .Where(a => a.id_projeto.Equals(atividade.id_projeto)).FirstOrDefault();

            var dataInicialProjeto = projeto.dt_inicio;
            var dataFinalProjeto = projeto.dt_fim;

            if (dataInicialProjeto > atividade.dt_inicio || dataInicialProjeto == null)
            {
                projeto.dt_inicio = atividade.dt_inicio;
            }
            if (dataFinalProjeto < atividade.dt_fim || dataFinalProjeto == null)
            {
                projeto.dt_fim = atividade.dt_fim;
            }

            atividadeDAO.Gravar(atividade);
        }

        public List<tb_atividade> listarAtividadesProjeto(int idProjeto)
        {
            var atividadesSelecionadas = atividadeDAO.Listar()
                .Where(a => a.id_projeto.Equals(idProjeto)).ToList();

            return atividadesSelecionadas; 
        }
    }
}
