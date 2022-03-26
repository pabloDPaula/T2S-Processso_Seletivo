using Microsoft.AspNetCore.Mvc;
using OperacaoConteiner.Models;
using OperacaoConteiner.Repositorio;
using System.Collections.Generic;

namespace OperacaoConteiner.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoRepositorio _movimentacaoRepositorio;
        private readonly IContainerRepositorio _containerRepositorio;
        public MovimentacaoController(IContainerRepositorio containerRepositorio, IMovimentacaoRepositorio movimentacaoRepositorio)
        {
            _containerRepositorio = containerRepositorio;
            _movimentacaoRepositorio = movimentacaoRepositorio;
        }
        public IActionResult Index()
        {
            List<MovimentacaoModel> Listacontainer = _movimentacaoRepositorio.BuscarTodos();
            return View(Listacontainer);
        }
        public IActionResult Cadastrar()
        {
            MovimentacaoModel movimentacao = new MovimentacaoModel();
            MovimentacaoContainerModel movimentacaoContainerModel = new MovimentacaoContainerModel();
            movimentacaoContainerModel.todosContainer = _containerRepositorio.BuscarTodos();
            movimentacaoContainerModel.movimentacao = movimentacao;
            return View(movimentacaoContainerModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(MovimentacaoModel movimentacao)
        {
            try
            {
                TempData["mensagemSucesso"] = "Movimentação cadastrada com sucesso!!";
                _movimentacaoRepositorio.Adicionar(movimentacao);
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["mensagemErro"] = "Ops, Erro ao cadastrar a movimentação, tente novamente mais tarde!!, mais detalhes:" + erro.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            MovimentacaoModel movimentacao = _movimentacaoRepositorio.ListarMovimentacaoPorId(id);
            return View(movimentacao);
        }

        [HttpPost]
        public IActionResult Atualizar(MovimentacaoModel movimentacao)
        {
            _movimentacaoRepositorio.Atualizar(movimentacao);
            return RedirectToAction("Index");
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            MovimentacaoModel movimentacao = _movimentacaoRepositorio.ListarMovimentacaoPorId(id);
            return View(movimentacao);
        }

        public IActionResult Apagar(int id)
        {
            _movimentacaoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public IActionResult maisDetalhes(int id)
        {
            ContainerModel container = _containerRepositorio.ListarContainerPorId(id);
            return View(container);
        }
    }
}
