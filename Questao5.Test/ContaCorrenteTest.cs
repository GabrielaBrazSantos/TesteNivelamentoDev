using Newtonsoft.Json;
using Questao5.Test.Commands.Requests;
using Questao5.Test.Commands.Responses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Questao5.Test
{
    public class ContaCorrenteTest
    {
        [Fact]
        public void CreditoRequisicao123Valor100ParaNumeroConta123()
        {
            //Arrange
            MovimentoRequest request = new MovimentoRequest("123",123,DateTime.Now,"C",100);
            //Act
            var ApiUrl = $"https://localhost:7140/api/Conta/Movimento";
            var JsonContent = System.Text.Json.JsonSerializer.Serialize(request);
            var httpContent = new StringContent(JsonContent, Encoding.UTF8, "application/json");
            ResponseMovimentoResult responseMovimento = new ResponseMovimentoResult();
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage result = httpClient.PostAsync(ApiUrl, httpContent).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var resultado = result.Content.ReadAsStringAsync();

                            responseMovimento = JsonConvert.DeserializeObject<ResponseMovimentoResult>(resultado.Result);                            
                        }
                    }
                }
                catch { }                
            }
            //Assert
            Assert.Equal(200, responseMovimento.StatusCode);
        }

        [Fact]
        public void CreditoRequisicao123SegundaTentativa()
        {
            //Arrange
            MovimentoRequest request = new MovimentoRequest("123", 123, DateTime.Now, "C", 100);
            //Act
            var ApiUrl = $"https://localhost:7140/api/Conta/Movimento";
            var JsonContent = System.Text.Json.JsonSerializer.Serialize(request);
            var httpContent = new StringContent(JsonContent, Encoding.UTF8, "application/json");
            ResponseMovimentoResult responseMovimento = new ResponseMovimentoResult();
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage result = httpClient.PostAsync(ApiUrl, httpContent).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var resultado = result.Content.ReadAsStringAsync();

                            responseMovimento = JsonConvert.DeserializeObject<ResponseMovimentoResult>(resultado.Result);
                        }
                    }
                }
                catch { }
            }
            //Assert
            Assert.Equal(200, responseMovimento.StatusCode);
        }

        [Fact]
        public void DebitoRequisicao1234Valor100ParaNumeroConta123()
        {
            //Arrange
            MovimentoRequest request = new MovimentoRequest("123", 123, DateTime.Now, "C", 100);
            //Act
            var ApiUrl = $"https://localhost:7140/api/Conta/Movimento";
            var JsonContent = System.Text.Json.JsonSerializer.Serialize(request);
            var httpContent = new StringContent(JsonContent, Encoding.UTF8, "application/json");
            ResponseMovimentoResult responseMovimento = new ResponseMovimentoResult();
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage result = httpClient.PostAsync(ApiUrl, httpContent).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var resultado = result.Content.ReadAsStringAsync();

                            responseMovimento = JsonConvert.DeserializeObject<ResponseMovimentoResult>(resultado.Result);
                        }
                    }
                }
                catch { }
            }
            //Assert
            Assert.Equal(200, responseMovimento.StatusCode);
        }

        [Fact]
        public void ConsultaSaldoNumeroConta123()
        {
            //Arrange
            int NumeroConta = 123;
            //Act
            var ApiUrl = $"https://localhost:7140/api/Conta/Saldo/{NumeroConta}";
            ResponseSaldo responseSaldoEsperado = new ResponseSaldo(123, "Katherine Sanchez", DateTime.Now, 1);
            ResponseSaldo responseSaldo = new ResponseSaldo();
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage result = httpClient.GetAsync(ApiUrl).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var resultado = result.Content.ReadAsStringAsync();

                            responseSaldo = JsonConvert.DeserializeObject<ResponseSaldo>(resultado.Result);
                        }
                    }
                }
                catch { }
            }
            //Assert
            Assert.Equal(responseSaldoEsperado, responseSaldo);
        }
    }
}