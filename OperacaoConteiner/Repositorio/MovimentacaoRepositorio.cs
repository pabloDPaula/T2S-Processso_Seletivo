using OperacaoConteiner.Data;
using OperacaoConteiner.Models;
using System.Collections.Generic;
using System.Linq;

namespace OperacaoConteiner.Repositorio
{
    public class MovimentacaoRepositorio : IMovimentacaoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public MovimentacaoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public MovimentacaoModel Adicionar(MovimentacaoModel movimentacao)
        {
            _bancoContext.Movimentacao.Add(movimentacao);
            _bancoContext.SaveChanges();
            return movimentacao;
        }

        public bool Apagar(int id)
        {
            MovimentacaoModel movimentacaoDB = ListarMovimentacaoPorId(id);
            if (movimentacaoDB == null) throw new System.Exception("Aconteceu um erro!!!");
            _bancoContext.Remove(movimentacaoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public MovimentacaoModel Atualizar(MovimentacaoModel movimentacao)
        {
            MovimentacaoModel movimentacaoDB = ListarMovimentacaoPorId(movimentacao.Id);
            if (movimentacaoDB == null) throw new System.Exception("Aconteceu um erro!!!");

            movimentacaoDB.tipoMovimentação = movimentacao.tipoMovimentação;
            movimentacaoDB.DataInicio = movimentacao.DataInicio;
            movimentacaoDB.DataFim = movimentacao.DataFim;

            _bancoContext.Movimentacao.Update(movimentacaoDB);
            _bancoContext.SaveChanges();
            return movimentacaoDB;
        }

        public List<MovimentacaoModel> BuscarTodos()
        {
            return _bancoContext.Movimentacao.ToList();
        }

        public MovimentacaoModel ListarMovimentacaoPorId(int id)
        {
            return _bancoContext.Movimentacao.FirstOrDefault(movimentacao => movimentacao.Id == id);
        }
    }
}
