using System;
using System.Collections;
using System.Collections.Generic;
using EP.CursoMVC.Application.ViewModels;

namespace EP.CursoMVC.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);
        ClienteViewModel ObterPorId(Guid id);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel ObterPorEmail(string email);
        ClienteViewModel Atualizar(ClienteViewModel clienteView);
        void Remover(Guid id);

    }
}