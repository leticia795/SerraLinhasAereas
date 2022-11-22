using SerraLinhasAereas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data.DAO
{
    public class PassagemDAO
    {
        private readonly string _connectionString =
            @"server=localhost;initial catalog=SERRA_LINHAS_AEREAS;integrated security=true;";

        public PassagemDAO()
        {
        }

        public void AdicionarPassagem(Passagem passagem)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT PASSAGEM VALUES (@IdPassagem, @Origem, @Destino, @DataOrigem , @DataDestino, @Valor)";

                    comando.Parameters.AddWithValue("@IdPassagem", passagem.IdPassagem);
                    comando.Parameters.AddWithValue("@Origem", passagem.Origem);
                    comando.Parameters.AddWithValue("@Destino", passagem.Destino);
                    comando.Parameters.AddWithValue("@DataOrigem", passagem.DataOrigem);
                    comando.Parameters.AddWithValue("@DataDestino", passagem.DataDestino);
                    comando.Parameters.AddWithValue("@Valor", passagem.Valor);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Passagem> BuscarTodasPassagens()
        {
            var listaPassagem = new List<Passagem>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM PASSAGEM";

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var passagemBuscada = new Passagem
                        {
                            IdPassagem = Convert.ToInt32(leitor["IdPassagem"].ToString()),
                        };

                        listaPassagem.Add(passagemBuscada);
                    }
                }
            }

            return listaPassagem;
        }

        public Passagem BuscarPorData(DateTime passagemCliente)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT IdPassagem, Origem, Destino, Valor, DataDeCompra, DataOrigem , DataDestino FROM Passagem WHERE DataDeCompra = @DataDeCompra;";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@IdPassagem", passagemCliente);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var passagemBuscado = new Passagem();
                        {
                            int IdPassagem = Convert.ToInt32(leitor["IdPassagem"].ToString());
                        };

                        return passagemBuscado;
                    }
                }
            }

            return null;
        }

        public Passagem BuscarPorOrigem(int passagemCliente)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT IdPassagem FROM PASSAGEM WHERE Origem = @Origem_PASSAGEM";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@Origem", passagemCliente);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var passagemBuscado = new Passagem
                        {
                            IdPassagem = Convert.ToInt32(leitor["IdPassagem"].ToString()),
                        };

                        return passagemBuscado;
                    }
                }
            }

            return null;
        }

        public Passagem BuscarPorDestino(int passagemCliente)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT IdPassagem FROM PASSAGEM WHERE Destino = @Destino_PASSAGEM";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@@Destino", passagemCliente);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var passagemBuscado = new Passagem
                        {
                            IdPassagem = Convert.ToInt32(leitor["IdPassagem"].ToString()),
                        };

                        return passagemBuscado;
                    }
                }
            }

            return null;
        }
        public void AtualizarPassagem(Passagem passagemCliente)
        {
            var listaPassagem = new List<Passagem>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE PASSAGEM SET Origem = @Origem, Destino = @Destino, DataOrigem = @DataOrigem, DataDestino = @DataDestino , Valor = @Valor WHERE IdPassagem = @IdPassagem";

                    comando.Parameters.AddWithValue("@Origem", passagemCliente.Origem);
                    comando.Parameters.AddWithValue("@Destino", passagemCliente.Destino);
                    comando.Parameters.AddWithValue("@DataOrigem", passagemCliente.DataOrigem);
                    comando.Parameters.AddWithValue("@DataDestino", passagemCliente.DataDestino);
                    comando.Parameters.AddWithValue("@Valor", passagemCliente.Valor);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        private Passagem ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var idPassagem = int.Parse(leitor["IdPassagem"].ToString());
            var origem = leitor["Origem"].ToString();
            var destino = leitor["Destino"].ToString();
            var dataOrigem = DateTime.Parse(leitor["DataOrigem"].ToString());
            var dataDestino = DateTime.Parse(leitor["DataDestino"].ToString());
            var valor = Convert.ToInt32(leitor["valor"].ToString());


            return new Passagem(idPassagem, origem, destino, dataOrigem, dataDestino, valor);
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
