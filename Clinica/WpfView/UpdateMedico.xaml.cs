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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controles;
using Modelos;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for UpdateMedico.xaml
    /// </summary>
    public partial class UpdateMedico : Window
    {
        public UpdateMedico()
        {
            InitializeComponent();
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Usuario usu = new Usuario();

                //usu.Nome = txtNome.Text;

                //UsuariosController usuariosController = new UsuariosController();
                //usuariosController.Adicionar(usu);

                MessageBox.Show("Usuário salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o usuário (" + ex.Message + ")");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
