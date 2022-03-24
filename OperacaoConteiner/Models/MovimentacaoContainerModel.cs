using System.Collections.Generic;

namespace OperacaoConteiner.Models
{
    public class MovimentacaoContainerModel
    {
        public MovimentacaoModel movimentacao { get; set; }
        public List<ContainerModel> todosContainer { get; set; }
    }
}
