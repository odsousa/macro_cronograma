using System.Collections.Generic;
using Macro_Cronograma.DAO;
using Macro_Cronograma.models;


namespace Macro_Cronograma.services
{
    class atribuicao
    {
        public tb_atribuicao atribuicaoModel { get; set; }
        public atribuicaoDAO atribuicaoDAO { get; set; }

        public List<string> listarAtribuicoes()
        {
            var atribuicoes = atribuicaoDAO.Listar();

            List<string> retornoAtribuicoes = new List<string>();

            foreach(var item in atribuicoes)
            {
                retornoAtribuicoes.Add(item.des_atribuicao);
            }

            return retornoAtribuicoes;
        }
    }
}
