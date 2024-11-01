using AutoMapper;
using Questao5.Application.Commands.Requests;
using Questao5.Entities;


namespace Questao5.Infrastructure.Profiles
{
    public class ProfileAutoMapper:Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<Idempotencia, IdempotenciaRequest>();            
        }
    }
}
