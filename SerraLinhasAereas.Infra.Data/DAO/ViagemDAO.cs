using SerraLinhasAereas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data.DAO
{
    public class ViagemDAO
    {
        private readonly string _connectionString =
            @"server=localhost;initial catalog=SERRA_LINHAS_AEREAS;integrated security=true;";

        public string codigoReserva { get; private set; }

        public ViagemDAO()
        {
        }
        public void MarcarViagem(Viagem viagem)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT VIAGEM VALUES (@CodigoReserva, @IdaVolta, @DataCompra, @ValorTotal , @PassagemIda, @PassagemVolta, @ResumoViagem)";

                    comando.Parameters.AddWithValue("@CodigoReserva", viagem.CodigoReserva);
                    comando.Parameters.AddWithValue("@IdaVolta", viagem.IdaVolta);
                    comando.Parameters.AddWithValue("@DataCompra", viagem.DataCompra);
                    comando.Parameters.AddWithValue("@ValorTotal", viagem.ValorTotal);
                    comando.Parameters.AddWithValue("@PassagemIda", viagem.PassagemIda);
                    comando.Parameters.AddWithValue("@PassagemVolta", viagem.PassagemVolta);
                    comando.Parameters.AddWithValue("@ResumoViagem", viagem.ResumoViagem);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

     
        public List<Viagem> BuscarTodasViagens()
        {
            var listarViagem = new List<Viagem>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT CodigoReserva, ResumoViagem FROM VIAGEM";

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var viagemBuscada = new Viagem
                        {
                            CodigoReserva = leitor["CodigoReserva"].ToString(),
                            ResumoViagem = leitor["PassagemIda"].ToString(),
                        };

                        listarViagem.Add(viagemBuscada);
                    }
                }
            }

            return listarViagem;
        }

        public void RemarcarViagem(Viagem viagem)
        {
            var listarViagem = new List<Viagem>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE VIAGEM SET CodigoReserva = @CodigoReserva, IdaVolta = @IdaVolta, DataCompra = @DataCompra, ValorTotal = @ValorTotal , PassagemIda = @PassagemIda, PassagemVolta = @PassagemVolta, ResumoViagem = @ResumoViagem, , ClienteExistente = @ClienteExistente WHERE VIAGEM";

                    comando.Parameters.AddWithValue("@CodigoReserva", viagem.CodigoReserva);
                    comando.Parameters.AddWithValue("@IdaVolta", viagem.IdaVolta);
                    comando.Parameters.AddWithValue("@DataCompra", viagem.DataCompra);
                    comando.Parameters.AddWithValue("@ValorTotal", viagem.ValorTotal);
                    comando.Parameters.AddWithValue("@PassagemIda", viagem.PassagemIda);
                    comando.Parameters.AddWithValue("@PassagemVolta", viagem.PassagemVolta);
                    comando.Parameters.AddWithValue("@ResumoViagem", viagem.ResumoViagem);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        private Viagem ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var CodigoReserva = leitor["codigoReserva"].ToString();
            var clienteExistente = int.Parse(leitor["ClienteExistente"].ToString());
            var idaVolta = bool.Parse(leitor["IdaVolta"].ToString());
            var dataCompra = DateTime.Parse(leitor["DataCompra"].ToString());
            var valorTotal = decimal.Parse(leitor["ValorTotal"].ToString());
            var passagemIda = int.Parse(leitor["PassagemIda"].ToString());
            var passagemVolta = int.Parse(leitor["PassagemVolta"].ToString());
            var resumoViagem = leitor["ResumoViagem"].ToString();


            return new Viagem ( codigoReserva,clienteExistente,idaVolta,dataCompra,valorTotal,passagemIda,passagemVolta,resumoViagem);
        }
        private void ConverterObjetoParaParametrosSQL(Passagem passagem, SqlCommand command)
        {
            command.Parameters.AddWithValue("@IdPassagem", passagem.IdPassagem);
            command.Parameters.AddWithValue("@Origem", passagem.Origem);
            command.Parameters.AddWithValue("@Destino", passagem.Destino);
            command.Parameters.AddWithValue("@DataDestino", passagem.DataDestino);
            command.Parameters.AddWithValue("@DataOrigem", passagem.DataOrigem);
            command.Parameters.AddWithValue("@Valor", passagem.Valor);
        }
    }
}
