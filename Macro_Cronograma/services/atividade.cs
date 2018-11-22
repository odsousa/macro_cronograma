using System.Collections.Generic;
using Macro_Cronograma.models;
using Macro_Cronograma.DAO;
using System.Linq;

namespace Macro_Cronograma.services
{
    public class atividade
    {
        tb_atividade atividadeModel = new tb_atividade();
        atividadeDAO atividadeDAO = new atividadeDAO();

        tb_projeto projetoModel = new tb_projeto();
        projetoDAO projetoDAO = new projetoDAO();

        tb_atribuicao atribuicaoModel = new tb_atribuicao();
        atribuicaoDAO atribuicaoDAO = new atribuicaoDAO();


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
