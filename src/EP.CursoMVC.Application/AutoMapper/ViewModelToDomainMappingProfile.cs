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
    class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteEnderecoViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ClienteEnderecoViewModel, Endereco>();
        }
    }

}