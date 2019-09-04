using Projeto02_AcessoDados.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02_AcessoDados.DAL
{
	public class ConvidadosDao : Dao<Convidado, string>
	{
		public override Convidado Buscar(string chave)
		{
			throw new NotImplementedException();
		}

		public int StatusInclusaoConvidado { get; set; }


		public override void Incluir(Convidado elemento)
		{
			try
			{
				AbrirConexao();
				cmd.CommandText = "pr_incluir_convidado";
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@cpf", elemento.Cpf);
				cmd.Parameters.AddWithValue("@idevento", elemento.EventoInfo.Id);
				cmd.Parameters.AddWithValue("@nome", elemento.Nome);
				cmd.Parameters.AddWithValue("@telefone", elemento.Telefone);
				cmd.Parameters.AddWithValue("@email", elemento.Email);

				//parametro de saída
				SqlParameter parameter = new SqlParameter();
				parameter.ParameterName = "@status";
				parameter.SqlDbType = SqlDbType.Int;
				parameter.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(parameter);

				cmd.ExecuteNonQuery();
				int status = (int)parameter.Value;
				StatusInclusaoConvidado = status;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				FecharConexao();
			}
		}

		//Método que retorna um conjunto de valores provenientes
		//da tabela TBConvidados, em forma de objetos - DataTable
		public DataTable ListarConvidados(int id)
		{
			DataTable table = new DataTable();

			try
			{
				AbrirConexao();

				string sql = " SELECT C.Cpf, C.Nome, C.Email, C.Telefone" +
					" FROM TBConvidados C, TBEventos E WHERE" +
					" C.IdEvento = E.Id AND C.IdEvento = " + id;

				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				adapter.SelectCommand = cmd;
				adapter.Fill(table);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				FecharConexao();
			}

			return table;
		}



		public override IEnumerable<Convidado> Listar(int id = 0)
		{
			List<Convidado> convidados = new List<Convidado>();

			try
			{
				if(id < 0)
				{
					throw new Exception("Não é permitido parâmetro negativo");
				}
				AbrirConexao();

				string sql = " SELECT * FROM TBConvidados";
				if(id > 0)
				{
					sql += " WHERE IdEvento = @IdEvento";
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@IdEvento", id);
				}
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Convidado c = new Convidado();
					c.Cpf = (string)reader["Cpf"];
					c.Nome = (string)reader["Nome"];
					c.Email = (string)reader["Email"];
					c.Telefone = (string)reader["Telefone"];
					c.EventoInfo = new EventosDao().Buscar((int)reader["IdEvento"]);

					convidados.Add(c);
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				FecharConexao();
			}

			return convidados;
		}
	}
}
