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
using System.Windows.Shapes;

namespace cinema.View
{
    /// <summary>
    /// Lógica interna para SessaoView.xaml
    /// </summary>
    public partial class SessaoView : Window
    {
        public SessaoView()
        {
            InitializeComponent();
        }
        public void btn_Salvar(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
