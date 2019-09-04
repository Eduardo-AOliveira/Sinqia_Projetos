using ProjetoWeb_CadastroEventos.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWeb_CadastroEventos.DAL
{
	public class ConvidadosDao
	{
		public static void IncluirConvidado(Convidado convidado)
		{
			using(var context = new EventosEntities())
			{
				context.Convidados.Add(convidado);
				context.SaveChanges();
			}
		}
	}
}