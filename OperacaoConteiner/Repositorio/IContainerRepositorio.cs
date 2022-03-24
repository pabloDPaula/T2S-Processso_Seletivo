using OperacaoConteiner.Models;
using System.Collections.Generic;

namespace OperacaoConteiner.Repositorio
{
    public interface IContainerRepositorio
    {
        List<ContainerModel> BuscarTodos();

        ContainerModel Adicionar(ContainerModel container);

        ContainerModel ListarContainerPorId(int id);

        ContainerModel Atualizar(ContainerModel container);
        bool Apagar(int id);
    }
}
