using Projeto02_AcessoDados.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01_CadastroEventos.RepositoryDao
{
	public sealed class Repository
	{
		static EventosDao eventosDao;
		static ConvidadosDao convidadosDao;

		public static EventosDao GetEventosDao()
		{
			if(eventosDao == null)
			{
				eventosDao = new EventosDao();
			}
			return eventosDao;
		}

		public static ConvidadosDao GetConvidadosDao()
		{
			if(convidadosDao == null)
			{
				convidadosDao = new ConvidadosDao();
			}
			return convidadosDao;
		}
	}
}
