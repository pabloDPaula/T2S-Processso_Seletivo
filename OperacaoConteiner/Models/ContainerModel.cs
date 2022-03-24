using OperacaoConteiner.Models.Enums;

namespace OperacaoConteiner.Models
{
    public class ContainerModel
    {
        public int Id { get; set; }
        public string nomeCliente { get; set; }
        public string numeroContainer { get; set; }
        public TipoContainer tipoContainer { get; set; }
        public StatusContainer statusContainer { get; set; }
        public CategoriaContainer categoriaContainer { get; set; }
    }
}
