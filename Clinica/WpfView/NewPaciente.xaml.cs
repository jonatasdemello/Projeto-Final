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
    /// Interaction logic for NewPaciente.xaml
    /// </summary>
    public partial class NewPaciente : Window
    {
        public NewPaciente()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // preencher dropdown convenio
            ConvenioController convenio = new ConvenioController();
            cbConvenio.ItemsSource = convenio.readConvenios();
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
                    Paciente paciente = new Paciente();
                    paciente.Nome = txtNome.Text;
                    paciente.CPF = txtCPF.Text;
                    paciente.Telefone = txtTelefone.Text;
                    paciente.Nascimento = (DateTime)dpDataNascimento.SelectedDate;
                    paciente.Convenio = (Convenio)cbConvenio.SelectedItem;

                    PacienteController pacienteController = new PacienteController();
                    pacienteController.createPaciente(paciente);

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
