using OperacaoConteiner.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacaoConteiner.Models
{
    public class MovimentacaoModel
    {
        public int Id { get; set; }
        public TipoMovimentacao tipoMovimentação { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        [ForeignKey("container")]
        public int IdContainer { get; set; }
        public virtual ContainerModel container { get; set; }
    }
}
