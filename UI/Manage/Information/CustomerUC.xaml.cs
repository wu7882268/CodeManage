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
using Models.Delegates;

namespace UI.Manage.Information
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerUC : UserControl
    {
        public CustomerUC()
        {
            InitializeComponent();
        }

        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            Delegates.JumpDelegate("UI.Manage.Information.CustomerAdd");
        }
    }
}
