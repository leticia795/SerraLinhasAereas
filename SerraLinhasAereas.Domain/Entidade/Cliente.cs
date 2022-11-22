using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Entidade
{
    public class Cliente
    {
        public long CPF { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Completo { get; set; }
        public Cliente cliente { get; set; }

        
        public Cliente(long cpf, string primeironome, string sobrenome, string nomecompleto, string rua, string cep, int numero, string bairro, string completo)
        {
            this.CPF = cpf;
            this.PrimeiroNome = primeironome;
            this.Sobrenome = sobrenome;
            this.NomeCompleto = nomecompleto;
            this.Rua = rua;
            this.Cep = cep;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Completo = completo;

        }

        public Cliente()
        {
        }

    }
}
