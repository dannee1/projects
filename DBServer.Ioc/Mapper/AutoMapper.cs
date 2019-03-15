using AutoMapper;
using DbServer.Api.DTO;
using DbServer.Domain.Entities;

namespace DBServer.Api.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() : this("MapProfile")
        {
        }

        protected MapProfile(string profileName) : base(profileName)
        {
            this.MapearDTOsParaEntidades();
            this.MapearEntidadesParaDTOs();
        }

        private void MapearEntidadesParaDTOs()
        {
            //Lancamento
            CreateMap<Lancamento, LancamentoDTO>();

            //ContaCorrente
            CreateMap<ContaCorrente, ContaCorrenteDTO>();

        }

        private void MapearDTOsParaEntidades()
        {

            //Lancamento
            CreateMap<LancamentoDTO, Lancamento>();

            //ContaCorrente
            CreateMap<ContaCorrenteDTO, ContaCorrente>();
        }
    }
}
