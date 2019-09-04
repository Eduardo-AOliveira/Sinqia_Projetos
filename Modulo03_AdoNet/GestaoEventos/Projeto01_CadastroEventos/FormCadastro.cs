using Projeto01_CadastroEventos.RepositoryDao;
using Projeto02_AcessoDados.DAL;
using Projeto02_AcessoDados.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto01_CadastroEventos
{
	public partial class FormCadastro : Form
	{
		public FormCadastro()
		{
			InitializeComponent();
			ListarEventos();
		}

		private void incluirEventoButton_Click(object sender, EventArgs e)
		{
			try
			{
				Evento evento = new Evento();
				evento.Descricao = descricaoTextBox.Text;
				evento.Responsavel = responsavelTextBox.Text;
				evento.Data = Convert.ToDateTime(dataMaskedTextBox.Text);
				evento.Preco = Convert.ToDouble(precoTextBox.Text);

				EventosDao dao = Repository.GetEventosDao();
				dao.Incluir(evento);

				ListarEventos();

				MessageBox.Show("Evento incluído com sucesso");
				//Limpando os campos de entrada
				descricaoTextBox.Clear();
				responsavelTextBox.Clear();
				dataMaskedTextBox.Clear();
				precoTextBox.Clear();

				descricaoTextBox.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);				
			}
		}

		private bool Loaded = false;
		private void ListarEventos()
		{

			try
			{
				Loaded = false;
				EventosDao dao = Repository.GetEventosDao();
				eventoComboBox.DataSource = dao.Listar();
				eventoComboBox.DisplayMember = "Descricao"; //Text
				eventoComboBox.ValueMember = "Id";          //Value
				Loaded = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void incluirConvidadoButton_Click(object sender, EventArgs e)
		{
			try
			{
				Convidado convidado = new Convidado();
				ConvidadosDao dao = Repository.GetConvidadosDao();

				convidado.Cpf = cpfTextBox.Text;
				convidado.Nome = nomeTextBox.Text;
				convidado.Email = emailTextBox.Text;
				convidado.Telefone = telefoneTextBox.Text;

				//obtendo o Id do evento a partir do ComboBox
				int id = (int)eventoComboBox.SelectedValue;

				convidado.EventoInfo = Repository.GetEventosDao().Buscar(id);

				//incluindo o convidado no banco de dados
				dao.Incluir(convidado);
				if(dao.StatusInclusaoConvidado == 1)
				{
					MessageBox.Show("Convidado alterado com sucesso");
				}
				else
				{
					MessageBox.Show("Convidado incluído com sucesso");
				}

				cpfTextBox.Clear();
				nomeTextBox.Clear();
				emailTextBox.Clear();
				telefoneTextBox.Clear();
				cpfTextBox.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buscarConvidadosButton_Click(object sender, EventArgs e)
		{
			try
			{
				int id = (int)eventoComboBox.SelectedValue;
				ConvidadosDao dao = Repository.GetConvidadosDao();
				//convidadosdataGridView.DataSource = dao.Listar(id);
				convidadosdataGridView.DataSource = dao.ListarConvidados(id);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, 
					"Erro", 
					MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
			}
		}

		private void eventoComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Loaded)
			{
				buscarConvidadosButton_Click(sender, e);
			}
		}
	}
}
