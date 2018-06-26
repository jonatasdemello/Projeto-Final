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

namespace WpfView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewMedico_Click(object sender, RoutedEventArgs e)
        {
            NewMedico newMedico = new NewMedico();
            newMedico.ShowDialog();
        }
        private void btnMedicos_Click(object sender, RoutedEventArgs e)
        {
            Medicos medicos = new Medicos();
            medicos.ShowDialog();
        }
        private void btnConsultas_Click(object sender, RoutedEventArgs e)
        {
            Consultas consultas = new Consultas();
            consultas.ShowDialog();
        }
        private void btnNewConsulta_Click(object sender, RoutedEventArgs e)
        {
            NewConsulta consulta = new NewConsulta();
            consulta.ShowDialog();
        }
        private void btnPaciente_Click(object sender, RoutedEventArgs e)
        {
            PacienteView paciente = new PacienteView();
            paciente.ShowDialog();
        }
        private void btnNewPaciente_Click(object sender, RoutedEventArgs e)
        {
            NewPaciente paciente = new NewPaciente();
            paciente.ShowDialog();
        }
    }
}
