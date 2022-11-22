using SerraLinhasAereas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data.DAO
{
    public class ClienteDAO
    {
        private string _connectionString =
            @"server=localhost;initial catalog=SERRA_LINHAS_AEREAS;integrated security=true;";

        public ClienteDAO()
        {
        }

        public void RegistrarCliente(Cliente cpfCliente)
        {
            using var conexao = new SqlConnection(_connectionString);
            conexao.Open();

            using (var comando = new SqlCommand())
            {
                comando.Connection = conexao;

                string sql = @"INSERT CLIENTE VALUES (@CPF, @PrimeiroNome, @Sobrenome, @Rua , @Cep, @Numero, @Bairro)";

                comando.Parameters.AddWithValue("@CPF", cpfCliente.CPF);
                comando.Parameters.AddWithValue("@PrimeiroNome", cpfCliente.PrimeiroNome);
                comando.Parameters.AddWithValue("@Sobrenome", cpfCliente.Sobrenome);
                comando.Parameters.AddWithValue("@Rua", cpfCliente.Rua);
                comando.Parameters.AddWithValue("@Cep", cpfCliente.Cep);
                comando.Parameters.AddWithValue("@Numero", cpfCliente.Numero);
                comando.Parameters.AddWithValue("@Bairro", cpfCliente.Bairro);

                comando.CommandText = sql;

                comando.ExecuteNonQuery();
            }
        }

        public Cliente BuscarClientePorCPF(long cpfCliente)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT PrimeiroNome,Sobrenome,Rua,Complemento FROM CLIENTE WHERE CPF = cpf;";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpfCliente);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var cpfBuscado = new Cliente
                        {
                            CPF = long.Parse((string)leitor["CPF".ToString()]),
                            PrimeiroNome = leitor["NOME"].ToString(),
                            Sobrenome = leitor["SobreNome"].ToString(),
                            Rua = leitor["Rua"].ToString(),
                            Completo = leitor["Complemento"].ToString()
                        };

                        return cpfBuscado;
                    }
                }
            }

            return null;
        }
        public List<Cliente> BuscarTodosClientes()
        {
            var listaClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using var comando = new SqlCommand();
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT PrimeiroNome, Sobrenome,CPF, Rua, Bairro FROM CLIENTE;";

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var clienteBuscada = new Cliente
                        {
                            CPF = Convert.ToInt32(leitor["CPF"].ToString()),
                            PrimeiroNome = leitor["PrimeiroNome"].ToString(),
                            Sobrenome = leitor["Sobrenome"].ToString(),
                            Rua = leitor["Rua"].ToString(),
                            Bairro = leitor["Bairro"].ToString(),
                        };

                        listaClientes.Add(clienteBuscada);
                    }
                }
            }

            return listaClientes;
        }

        public void AtualizarCliente(Cliente cpfClientes)
        {
            var listaClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE CLIENTE SET PrimeiroNome = @PrimeiroNome, Sobrenome = @Sobrenome, Cep = @Cep, Rua = @Rua , Numero = @Numero, Bairro = @Bairro WHERE CPF = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpfClientes.CPF);
                    comando.Parameters.AddWithValue("@PrimeiroNome", cpfClientes.PrimeiroNome);
                    comando.Parameters.AddWithValue("@Sobrenome", cpfClientes.Sobrenome);
                    comando.Parameters.AddWithValue("@Cep", cpfClientes.Cep);
                    comando.Parameters.AddWithValue("@Rua", cpfClientes.Rua);
                    comando.Parameters.AddWithValue("@Numero", cpfClientes.Numero);
                    comando.Parameters.AddWithValue("@Bairro", cpfClientes.Bairro);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void DeletarCliente(int cliente)
        {
            var listaClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM CLIENTE WHERE CPF = @CPF";

                    comando.Parameters.AddWithValue("@CPF", cliente);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        private Cliente ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var cpf = long.Parse(leitor["CPF"].ToString());
            var primeironome = leitor["PrimeiroNome"].ToString();
            var nomecompleto = leitor["NomeCompleto"].ToString();
            var sobrenome = leitor["Sobrenome"].ToString();
            var cep = leitor["Cep"].ToString();
            var rua = leitor["Rua"].ToString();
            var bairro = Convert.ToInt32(leitor["Bairro"].ToString());
            var numero = leitor["Numero"].ToString();
            var completo = leitor["Completo"].ToString();

            return new Cliente(cpf, primeironome, sobrenome, nomecompleto ,cep, rua, bairro, numero, completo);
        }
        private void ConverterObjetoParaParametrosSQL(Cliente cliente, SqlCommand command)
        {
            command.Parameters.AddWithValue("@CPF", cliente.CPF);
            command.Parameters.AddWithValue("@NOME", cliente.PrimeiroNome);
            command.Parameters.AddWithValue("@SOBRENOME", cliente.Sobrenome);
            command.Parameters.AddWithValue("@ENDERECO_CEP", cliente.Cep);
            command.Parameters.AddWithValue("@ENDERECO_RUA", cliente.Rua);
            command.Parameters.AddWithValue("@ENDERECO_BAIRRO", cliente.Bairro);
            command.Parameters.AddWithValue("@ENDERECO_NUMERO", cliente.Numero);
            command.Parameters.AddWithValue("@ENDERECO_COMPLEMENTO", cliente.Completo);
        }

    }
}
