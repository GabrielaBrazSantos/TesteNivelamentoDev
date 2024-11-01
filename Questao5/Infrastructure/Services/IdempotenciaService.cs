using AutoMapper;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Interfaces;
using Questao5.Entities;
using Questao5.Infrastructure.Interfaces;

namespace Questao5.Infrastructure.Services
{
    public class IdempotenciaService : IIdempotenciaService
    {
        private readonly IIdempotencia _repository;
        private readonly IMapper _mapper;
        public IdempotenciaService(IIdempotencia repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<RequestResult> Add(IdempotenciaRequest Objeto)
        {           
            try
            {
                Idempotencia entity = new Idempotencia() { ChaveIdempotencia = Guid.NewGuid().ToString(), Requisicao = Objeto.Requisicao, Resultado = Objeto.Resultado };
                await _repository.Add(entity);
                return new RequestResult().Ok(Objeto);                
            }
            catch(Exception ex) 
            {
               return new RequestResult().BadRequest(ex.Message, Objeto);
            }            
        }

        public async Task<RequestResult> GetById(string Id)
        {
            try
            {   
                var idempotencia = await _repository.GetById(Id);
                if (idempotencia != null)
                {
                    IdempotenciaRequest request = _mapper.Map<IdempotenciaRequest>(idempotencia);
                    return new RequestResult().Ok(request);
                }
                else
                    return new RequestResult().NotFound();
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }       
    }
}
