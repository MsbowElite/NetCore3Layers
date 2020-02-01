using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Layers.API.Models
{
    public class AtendimentoDTO
    {
        public int NumAtd { get; set; }
        public string CodCategAtd { get; set; }
        public string DescrAtd { get; set; }
        public string UsrResponAtd { get; set; }
        public string UsrCadAtd { get; set; }
        public int NumCcmAtd { get; set; }
        public byte StatusAtd { get; set; }
        public DateTime? DataFimAtd { get; set; }
        public int CodPesAtd { get; set; }
        public byte RetorAtenAtd { get; set; }
        public short? EmpresaAtd { get; set; }
        public string ObraAtd { get; set; }
        public int? ProdUnidAtd { get; set; }
        public int? NumPerAtd { get; set; }
        public DateTime DataPrevistaAtd { get; set; }
        public DateTime DataCadAtd { get; set; }
        public string ObsCancelAtd { get; set; }
        public string UsrCancelAtd { get; set; }
        public int? NumVtwfAtd { get; set; }
        public byte? AnexosAtd { get; set; }
        public bool? ReincidenteAtd { get; set; }
        public decimal? VlrMaoObraAtd { get; set; }
        public byte? TipoAtd { get; set; }
    }
}
