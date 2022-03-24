using OperacaoConteiner.Data;
using OperacaoConteiner.Models;
using System.Collections.Generic;
using System.Linq;

namespace OperacaoConteiner.Repositorio
{
    public class ContainerRepositorio : IContainerRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContainerRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
           
        public ContainerModel Adicionar(ContainerModel container)
        {
            _bancoContext.Container.Add(container);
            _bancoContext.SaveChanges();
            return container;
        }

        public bool Apagar(int id)
        {
            ContainerModel containerDB = ListarContainerPorId(id);
            if (containerDB == null) throw new System.Exception("Aconteceu um erro!!!");
            _bancoContext.Remove(containerDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public ContainerModel Atualizar(ContainerModel container)
        {
            ContainerModel containerDB = ListarContainerPorId(container.Id);
            if (containerDB == null) throw new System.Exception("Aconteceu um erro!!!");

            containerDB.nomeCliente = container.nomeCliente;
            containerDB.numeroContainer = container.numeroContainer;
            containerDB.tipoContainer = container.tipoContainer;
            containerDB.statusContainer = container.statusContainer;
            containerDB.categoriaContainer = container.categoriaContainer;

            _bancoContext.Container.Update(containerDB);
            _bancoContext.SaveChanges();
            return containerDB;
        }

        public List<ContainerModel> BuscarTodos()
        {
            return _bancoContext.Container.ToList();
        }

        public ContainerModel ListarContainerPorId(int id)
        {
            return _bancoContext.Container.FirstOrDefault(container => container.Id == id);
        }
    }
}
