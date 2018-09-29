using System;
using System.Collections.Generic;

namespace Macro_Cronograma.models
{
    public partial class tb_atividade
    {
        public int id_atividade { get; set; }
        public int id_projeto { get; set; }
        public string des_atividade { get; set; }
        public DateTime dt_inicio { get; set; }
        public DateTime? dt_fim { get; set; }
        public string cod_cor_grafico { get; set; }
        public bool flag_deadline { get; set; }

        public tb_projeto IdProjetoNavigation { get; set; }
    }
}
