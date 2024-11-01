using System;
using System.Globalization;
using System.Security.AccessControl;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace Questao1
{
    public class ContaBancaria 
    {

        private int _numero { get; set; }
        public string _titular { get; set; }        
        private double _saldo { get; set; }
        
        public int numero
        {
            get => _numero;            
        }

        public string titular
        {
            get => _titular;
            set { _titular = value; }
        }
        public double saldo { get => _saldo; }
        
        private double taxaSaque = 3.50d;
       
        public ContaBancaria(int numero, string titular, double depositoInicial = 0) 
        { 
            _numero = numero;
            _titular = titular;
            _saldo = depositoInicial;
        }


        public void Deposito(double valor)
        {
            _saldo = _saldo + valor;
        }

        public void Saque(double valor) 
        {
            _saldo = _saldo - taxaSaque - valor;
        }

        public void Exibir()
        {
            Console.WriteLine($"Conta: {numero}, Titular: {titular}, Saldo: {saldo:C}.");
        }
    }
}
