using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Infra.Data.Repository;
using EP.CursoMVC.Application.Interfaces;
using EP.CursoMVC.Application.ViewModels;

namespace EP.CursoMVC.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel);
            cliente.Enderecos.Add(endereco);
            cliente.DataCadastro = DateTime.Now;

            _clienteRepository.Adicionar(cliente);

            return clienteEnderecoViewModel;

        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteRepository.Atualizar(cliente);
            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
