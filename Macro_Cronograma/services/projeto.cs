using System.Collections.Generic;
using Macro_Cronograma.models;
using Macro_Cronograma.DAO;
using System.Linq;

namespace Macro_Cronograma.services
{
    class projeto
    {
        public tb_projeto projetoModel { get; set; }
        public projetoDAO projetoDAO { get; set; }

        public void gravarProjeto(tb_projeto projeto)
        {
            projetoDAO.Gravar(projeto);
        }

        public void excluirProjeto(tb_projeto projeto)
        {
            var projetoSelecionado = buscarProjeto(projeto.id_projeto);
            projetoDAO.Excluir(projetoSelecionado.id_projeto);
           
        }

        public tb_projeto buscarProjeto(int idProjeto)
        {
            var projetoSelecionado = projetoDAO.Listar()
                .Where(a => a.id_projeto.Equals(idProjeto)).FirstOrDefault();

            return projetoSelecionado;
        }

        public List<tb_projeto> listarTodosOsProjetos()
        {
            var projetos = projetoDAO.Listar();

            return projetos;
        }
    }
}
