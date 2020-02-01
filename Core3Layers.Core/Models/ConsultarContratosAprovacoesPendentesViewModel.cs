using System;
using System.Collections.Generic;
using System.Text;

namespace Core3LayersAPI.Core.Models
{
    public class ConsultarContratosAprovacoesPendentesViewModel
    {
        public object Empresa_cont { get; set; }
        public string Desc_emp { get; set; }
        public string Obra_cont { get; set; }
        public string Descr_obr { get; set; }
        public object Cod_cont { get; set; }
        public string Quem_cont { get; set; }
        public string Fornecedor { get; set; }
        public object DtInicio_cont { get; set; }
        public object DtFim_cont { get; set; }
        public string Obs_cont { get; set; }
        public object TotalReal { get; set; }
        public string EmpObra { get; set; }
        public object qtdeRegistros { get; set; }
        public object AprovacaoSeqUsuario { get; set; }
    }
}
