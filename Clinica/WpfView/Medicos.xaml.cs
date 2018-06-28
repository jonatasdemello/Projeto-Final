﻿using System;
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
    /// Interação lógica para Medicos.xam
    /// </summary>
    public partial class Medicos : Window
    {
        public Medicos()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MedicoController medicoController = new MedicoController();
            dgMedicos.ItemsSource = medicoController.readMedicos();
        }

        private void dgMedicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = ((DataGrid)sender);
            Medico med = (Medico)dg.Items[dg.SelectedIndex];
        }
    }
}
