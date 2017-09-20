﻿using System.Collections;
using System.Collections.Generic;
using EP.CursoMvc.Domain.Entities;

namespace EP.CursoMvc.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();

    }

}