using System;
using System.Collections.Generic;

namespace Macro_Cronograma.models
{
    public partial class tb_projeto
    {
        public tb_projeto()
        {
            tb_atividade = new HashSet<tb_atividade>();
        }

        public int id_projeto { get; set; }
        public string des_projeto { get; set; }
        public DateTime dt_inicio { get; set; }
        public DateTime dt_fim { get; set; }

        public ICollection<tb_atividade> tb_atividade { get; set; }
    }
}
