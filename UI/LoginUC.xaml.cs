using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;
using Pen = System.Drawing.Pen;
using Point = System.Drawing.Point;

namespace UI
{
    /// <summary>
    /// LoginUC.xaml 的交互逻辑
    /// </summary>
    public partial class LoginUC : UserControl
    {
        public LoginUC()
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
                LoginWindow.login.Hide();
                MainWindow main = new MainWindow();
                main.Show();
                TextBox_mm.Password = "";
                TextBox_yzm.Text = "";
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
    public class VerifyCodeHelper
    {
        public static string yzm;
        public static Bitmap CreateVerifyCode(out string code)
        {
            //建立Bitmap对象，绘图
            Bitmap bitmap = new Bitmap(200, 60);
            Graphics graph = Graphics.FromImage(bitmap);
            graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, 200, 60);
            Font font = new Font(System.Drawing.FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            Random r = new Random();
            string letters = "ABCDEFGHIJKLMNPQRSTUVWXYZ0123456789";

            StringBuilder sb = new StringBuilder();
            yzm = "";
            //添加随机的五个字母
            for (int x = 0; x < 4; x++)
            {
                string letter = letters.Substring(r.Next(0, letters.Length - 1), 1);
                yzm += letter;
                sb.Append(letter);
                graph.DrawString(letter, font, new SolidBrush(Color.Black), x * 38, r.Next(0, 15));
            }
            code = sb.ToString();

            //混淆背景
            Pen linePen = new Pen(new SolidBrush(Color.Black), 2);
            for (int x = 0; x < 6; x++)
                graph.DrawLine(linePen, new Point(r.Next(0, 199), r.Next(0, 59)), new Point(r.Next(0, 199), r.Next(0, 59)));
            return bitmap;
        }
    }
    public class ImageFormatConvertHelper
    {
        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);
        /// <summary>  
        /// 从bitmap转换成ImageSource  
        /// </summary>  
        /// <param name="icon"></param>  
        /// <returns></returns>  
        public static ImageSource ChangeBitmapToImageSource(Bitmap bitmap)
        {
            //Bitmap bitmap = icon.ToBitmap();  
            IntPtr hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            if (!DeleteObject(hBitmap))
            {
                throw new System.ComponentModel.Win32Exception();
            }
            return wpfBitmap;
        }

    }
}
