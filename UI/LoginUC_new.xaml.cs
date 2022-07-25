using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
using Helpers;
using Models.Interfaces;
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;
using Pen = System.Drawing.Pen;
using Point = System.Windows.Point;

namespace UI
{
    /// <summary>
    /// LoginUC_new.xaml 的交互逻辑
    /// </summary>
    public partial class LoginUC_new : UserControl
    {
        ILogInBusiness logInBusiness = new LogInBusiness();
        public LoginUC_new()
        {
            InitializeComponent();
        }

        private void Buttonloginin_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_yzm.Text == null || TextBox_yzm.Text == "")
            {
                MessageBox.Show("请输入验证码", "错误", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            else if (!TextBox_yzm.Text.ToUpper().Equals(VerifyCodeHelper.yzm.ToUpper()))
            {
                MessageBox.Show("验证码错误", "错误", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                GetImage();
            }
            else
            {
                (bool b, string msg) = logInBusiness.Login(TextBox_id.Text.Trim(), TextBox_mm.Password.Trim());
                if (b)
                {
                    LoginWindow.login.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                    TextBox_mm.Password = "";
                    TextBox_yzm.Text = "";
                }
                else
                {
                    MessageBox.Show(msg, "错误", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    GetImage();
                }
            }
        }
        private void TextBox_id_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_id.Text == null || TextBox_id.Text == "")
            {
                Label_id.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_id_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_id.Text == null || TextBox_id.Text == "")
            {
                Label_id.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_mm_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_mm.Password == null || TextBox_mm.Password == "")
            {
                Label_mm.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_mm_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_mm.Password == null || TextBox_mm.Password == "")
            {
                Label_mm.Visibility = Visibility.Visible;
            }
        }
        private void TextBox_yzm_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_yzm.Text == null || TextBox_yzm.Text == "")
            {
                Label_yzm.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_yzm_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_yzm.Text == null || TextBox_yzm.Text == "")
            {
                Label_yzm.Visibility = Visibility.Visible;
            }
        }
        private void Imgyzm_Loaded(object sender, RoutedEventArgs e)
        {
            GetImage();
        }

        private void Buttonyzm_Click(object sender, RoutedEventArgs e)
        {
            GetImage();
        }
        public string GetImage()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            ImageSource imageSource = ImageFormatConvertHelper.ChangeBitmapToImageSource(bitmap);
            imgyzm.Source = imageSource;
            return code;
        }
    }


}
