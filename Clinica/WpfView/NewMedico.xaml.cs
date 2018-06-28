using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Modelos;
using Controles;

namespace WpfView
{
    /// <summary>
    /// Lógica interna para NewMedico.xaml
    /// </summary>
    public partial class NewMedico : Window
    {
        public NewMedico()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // preencher dropdown contas
            ContaController contas = new ContaController();
            var ct = contas.readContas();
            cbConta.ItemsSource = ct;

            // preencher dropdown especialidades
            EspecialidadeController especialidade = new EspecialidadeController();
            var es = especialidade.readEspecialidades();
            cbEspecialidade.ItemsSource = es;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpDataNascimento.SelectedDate == null)
                {
                    MessageBox.Show("Informe a data de nascimento!");
                }
                else
                {
                    Medico medico = new Medico();
                    medico.Nome = txtNome.Text;
                    medico.Nascimento = (DateTime)dpDataNascimento.SelectedDate;
                    medico.Telefone = txtTelefone.Text;
                    medico.CPF = txtCPF.Text;
                    medico.conta = (Conta)cbConta.SelectedItem;
                    medico.CRM = txtCRM.Text;
                    medico.Especialidade = (Especialidade)cbEspecialidade.SelectedItem;
                    medico.Turno = txtTurno.Text;

                    MedicoController medicoController = new MedicoController();
                    medicoController.createMedico(medico);

                    MessageBox.Show("Usuário salvo com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o usuário (" + ex.Message + ")");
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
