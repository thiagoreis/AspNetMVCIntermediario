using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMVC.Application.ViewModels;

namespace EP.CursoMVC.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cliente, ClienteEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Endereco, ClienteEnderecoViewModel>();
        }
    }
}
