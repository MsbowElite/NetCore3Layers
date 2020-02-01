using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Layers.API.Models;
using Core3LayersAPI.Core.Models;

namespace Core3Layers.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<AtendimentoDTO, Atendimento>(MemberList.Source);
            //CreateMap<Atendimento, AtendimentoDTO>(MemberList.Source);
            //CreateMap<ConsultarContratosAprovacoesPendentesViewModel, Abastecimento>(MemberList.Source);
            //CreateMap<Entities.Users, UserModel>().ForMember(x => x.Password, opt => opt.Ignore());
            //CreateMap<Company, Entities.Companies>(MemberList.Source);
            //CreateMap<Entities.Users, UserAuthModel>(MemberList.Source);
        }
    }
}
