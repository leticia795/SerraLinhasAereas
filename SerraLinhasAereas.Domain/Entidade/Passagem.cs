using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Entidade
{
    public class Passagem
    {
        private object idPassagem;

        public int IdPassagem { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataOrigem { get; set; }
        public DateTime DataDestino { get; set; }
        public int  Valor { get; set; }
        public Cliente Cliente { get; set; }


        public Passagem(int idPassagem, string origem, string destino, DateTime dataOrigem, DateTime dataDestino, int valor)
        {
            this.IdPassagem = idPassagem;
            this.Origem = origem;
            this.Destino = destino;
            this.Valor = valor;
            this.DataOrigem = dataOrigem;
            this.DataDestino = dataDestino;

        }
        public Passagem()
        {

        }
        public override string ToString()
        {
            return $"---- Passagem ---- \nID Passagem:{IdPassagem} \nOrigem:{Origem} \nDestino:{Destino} \nValor da passagem:{Valor} \nData origem:{DataOrigem} \nData Destino:{DataDestino}";
        }
    }
}
