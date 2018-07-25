using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.ApplicationCore.Entity
{
   public class Profissao
    {
        //ctor
        public Profissao()
        {

        }

        public int Profissaoid { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string CBO { get; set; }

        public ICollection<ProfissaoCliente> ProfissoesClientes { get; set; }



    }
}
