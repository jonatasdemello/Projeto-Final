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
using Controles;
using Modelos;

namespace WpfView
{
    /// <summary>
    /// Lógica interna para PacienteView.xaml
    /// </summary>
    public partial class PacienteView : Window
    {
        public PacienteView()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PacienteController pacienteController = new PacienteController();
            dgPacientes.ItemsSource = pacienteController.readPacientes();
        }

        private void dgPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = ((DataGrid)sender);
            Paciente pac = (Paciente)dg.Items[dg.SelectedIndex];
        }
    }
}
