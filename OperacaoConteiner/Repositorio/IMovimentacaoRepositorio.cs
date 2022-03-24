using OperacaoConteiner.Models;
using System.Collections.Generic;

namespace OperacaoConteiner.Repositorio
{
    public interface IMovimentacaoRepositorio
    {
        MovimentacaoModel Adicionar(MovimentacaoModel movimentacao);

        List<MovimentacaoModel> BuscarTodos();

        MovimentacaoModel ListarMovimentacaoPorId(int id);

        MovimentacaoModel Atualizar(MovimentacaoModel movimentacao);
        bool Apagar(int id);
    }
}
