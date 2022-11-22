using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Entidade
{
    public class Viagem: Passagem
    {
        public string CodigoReserva { get; set; }
        public int ClienteExistente { get; set; }
        public bool IdaVolta { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorTotal { get; set; }
        public int PassagemIda { get; set; }
        public int PassagemVolta { get; set; }
        public string ResumoViagem { get; set; }
        public Passagem passagem { get; set; }
        public Viagem(string codigoReserva, int clienteExistente, bool idaVolta , DateTime dataCompra, decimal valorTotal, int passagemIda, int passagemVolta, string resumoViagem )
        {
            this.CodigoReserva = codigoReserva;
            this.ClienteExistente = clienteExistente; 
            this.IdaVolta = idaVolta;   
            this.DataCompra = dataCompra;   
            this.ValorTotal = valorTotal;
            this.PassagemIda = passagemIda;
            this.PassagemVolta = passagemVolta;
            this.ResumoViagem = resumoViagem;   
        }

        public Viagem()
        {

        }

        public override string ToString()
        {
            var resumoviagem = "";
            if (IdaVolta == true)
            {
                return $"Passagem: - Origem: {Origem} - Destino: {Destino}" +
                $"\n Data de Origem: {DataOrigem.ToShortDateString()}  - Valor Passagem {Valor} " +
                $"\n Data de Destino: {DataDestino.ToShortDateString()}  - Valor Passagem {Valor} " +
                $"\nCliente: {Cliente.NomeCompleto} CPF: {Cliente.CPF} ";
            }
            else
            {
                return $"Passagem: - Origem: {Origem}" +
                      $"\n Data de Origem: {DataOrigem.ToShortDateString()}  - Valor Passagem {Valor} " +
                      $"\nCliente: {Cliente.NomeCompleto} CPF: {Cliente.CPF} ";
            }
            return resumoviagem;
        }
    }
}
