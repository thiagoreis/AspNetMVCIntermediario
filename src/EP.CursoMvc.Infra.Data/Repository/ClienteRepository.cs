using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Interfaces.Repository;

namespace EP.CursoMvc.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.Cpf == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Ativo);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM CLIENTES";

            return cn.Query<Cliente>(sql);

        }

        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Clientes c " +
                      "LEFT JOIN Enderecos e " +
                      "ON c.ClienteId = e.ClienteId " +
                      "WHERE c.ClienteId = @sid";

            var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                }, new { sid = id }, splitOn: "ClienteId, EnderecoId");

            throw new Exception("THE BOMB HAS BEEN PLANTED!!!!!");

            return cliente.FirstOrDefault();
        }
    }
}