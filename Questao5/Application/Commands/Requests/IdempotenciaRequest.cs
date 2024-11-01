namespace Questao5.Application.Commands.Requests
{
    public class IdempotenciaRequest:ICommand
    {
        public string Requisicao { get; set; }
        public string Resultado { get; set; }

        public bool IsValid => Validate();

        private bool Validate()
        {
            return
                this.Requisicao.Length > 0;
        }
    }
}
