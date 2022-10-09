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
using BLL;
using Models;
using Models.Infos;
using Models.Interfaces;

namespace UI.Manage.Information
{
    /// <summary>
    /// SupplierUC.xaml 的交互逻辑
    /// </summary>
    public partial class SupplierAdd : UserControl
    {
        public SupplierAdd()
        {
            InitializeComponent();
            DataContext = supplierInfo;
        }
        SupplierInfo supplierInfo = new SupplierInfo();
        ISupplierBusiness supplierBusiness = new SupplierBusiness();

        private void Button_add_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsCheck())
            {
                supplierInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //supplierInfo.userId = ApiStatic.UserId;
                supplierBusiness.Save(supplierInfo);
            }
        }

        private bool IsCheck()
        {
            if (string.IsNullOrEmpty(supplierInfo.supplierName))
            {
                MessageBox.Show("失败，填写供应商名称", "提示", MessageBoxButton.OK);
                return false;
            }
            if (string.IsNullOrEmpty(supplierInfo.phone))
            {
                MessageBox.Show("失败，填写供应商电话", "提示", MessageBoxButton.OK);
                return false;
            }
            return true;
        }
    }
}
