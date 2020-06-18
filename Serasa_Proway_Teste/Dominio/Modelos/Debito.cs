using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Modelos
{
    public class Debito : Base
    {
        [ForeignKey("Empresa")]
        public int EmpresaId {  get; set; }
        public Empresa Empresa { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Descricao { get; set; }
               
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy -MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
    }
}
