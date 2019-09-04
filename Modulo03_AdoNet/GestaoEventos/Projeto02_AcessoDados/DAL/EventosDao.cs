using Projeto02_AcessoDados.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02_AcessoDados.DAL
{
	public class EventosDao : Dao<Evento, int>
	{
		public override Evento Buscar(int chave)
		{
			Evento evento = null;

			try
			{
				AbrirConexao();
				cmd.CommandText = "SELECT * FROM TBEventos WHERE Id = @Id";
				cmd.CommandType = CommandType.Text;

				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@Id", chave);
				reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					evento = new Evento();

					evento.Id = (int)reader["Id"];
					evento.Descricao = reader["Descricao"].ToString();
					evento.Responsavel = reader["Responsavel"].ToString();
					evento.Data = (DateTime)reader["Data"];
					evento.Preco = (double)reader["Preco"];
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

			return evento;
		}

		public override void Incluir(Evento elemento)
		{
			try
			{
				AbrirConexao();
				cmd.CommandText = "INSERT INTO TBEventos (Descricao, Responsavel," +
					"Data, Preco) VALUES (@Descricao, @Responsavel, @Data, @Preco)";
				cmd.CommandType = CommandType.Text;

				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@Descricao", elemento.Descricao);
				cmd.Parameters.AddWithValue("@Responsavel", elemento.Responsavel);
				cmd.Parameters.AddWithValue("@Data", elemento.Data);
				cmd.Parameters.AddWithValue("@Preco", elemento.Preco);

				cmd.ExecuteNonQuery();
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

		public override IEnumerable<Evento> Listar(int id = 0)
		{
			List<Evento> eventos = new List<Evento>();

			try
			{
				if(id != 0)
				{
					throw new Exception("Nenhum parâmetro deve ser informado");
				}

				AbrirConexao();
				cmd.CommandText = "SELECT * FROM TBEventos";
				cmd.CommandType = CommandType.Text;

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Evento evento = new Evento();

					evento.Id = (int)reader["Id"];
					evento.Descricao = reader["Descricao"].ToString();
					evento.Responsavel = reader["Responsavel"].ToString();
					evento.Data = (DateTime)reader["Data"];
					evento.Preco = (double)reader["Preco"];

					eventos.Add(evento);
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

			return eventos;
		}
	}
}
