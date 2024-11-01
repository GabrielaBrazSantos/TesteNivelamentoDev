

using Questao5.Application.Commands;
using Questao5.Application.Commands.Responses;


namespace Questao5.Application.Handlers
{
    public interface IHandler<T>
    where T : ICommand
    {
        Task<RequestResult> Handle(T command);
    }
}
