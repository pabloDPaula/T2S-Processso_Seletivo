using Microsoft.AspNetCore.Mvc;
using OperacaoConteiner.Models;
using OperacaoConteiner.Repositorio;
using System.Collections.Generic;

namespace OperacaoConteiner.Controllers
{
    public class ContainerController : Controller
    {
        private readonly IContainerRepositorio _containerRepositorio;
        public ContainerController(IContainerRepositorio containerRepositorio)
        {
            _containerRepositorio = containerRepositorio;
        }
        public IActionResult Index()
        {
            List<ContainerModel> Listacontainer = _containerRepositorio.BuscarTodos();
            return View(Listacontainer);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ContainerModel container)
        {
            _containerRepositorio.Adicionar(container);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            ContainerModel container = _containerRepositorio.ListarContainerPorId(id);
            return View(container);
        }

        [HttpPost]
        public IActionResult Atualizar(ContainerModel container)
        {
            _containerRepositorio.Atualizar(container);
            return RedirectToAction("Index");
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContainerModel container = _containerRepositorio.ListarContainerPorId(id);
            return View(container);
        }

        public IActionResult apagar(int id)
        {
            _containerRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
