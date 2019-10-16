using System.Windows;
using System.Windows.Controls;

namespace Calculator_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string anxiazhi = "";
        private double result1num = 0.0;
        public MainWindow()
        {
            InitializeComponent();
        }
        //运算方法
        private void OperationNum(string s )
        {
            if (result1.Text != "")
            {
                switch (anxiazhi)
                {
                    case "":
                        result1num = double.Parse(result1.Text);
                        anxiazhi = s;
                        break;
                    case "x_2":
                        result1num = System.Math.Pow(double.Parse(result1.Text), 2); 
                        anxiazhi = s;
                        break;
                    case "+":
                        result1num = result1num + double.Parse(result1.Text);
                        anxiazhi = s;
                        break;
                    case "-":
                        result1num = result1num - double.Parse(result1.Text);
                        anxiazhi = s;
                        break;
                    case "*":
                        result1num = result1num * double.Parse(result1.Text);
                        anxiazhi = s;
                        break;
                    case "/":
                        if (double.Parse(result1.Text) != 0.0)
                        {
                            result1num = result1num / double.Parse(result1.Text);
                        }
                        else
                        {
                            result1num = 0.0;
                        }
                        anxiazhi = s;
                        break;
                    default: break;
                }
            }
            else
            {
                anxiazhi = s;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (anxiazhi == "=")
            {
                gongshi.Text = "";
                result1.Text = "";
                anxiazhi = "";
                result1num = 0.0;
            }
            string s = ((Button)sender).Content.ToString();
            result1.Text = result1.Text + s;
            gongshi.Text = gongshi.Text + s;
        }
        //按运算符号的事件处理
        private void fuhao_Click_1(object sender, RoutedEventArgs e)
        {
            if (anxiazhi == "=")
            {
                gongshi.Text = result1.Text;
                anxiazhi = "";
            }
            string s = ((Button)sender).Content.ToString();//获得按钮文本内容
            gongshi.Text = gongshi.Text + s;
            OperationNum(s);
            result1.Text = "";
        }
        //按“=”号计算结果
        private void result1_Click_1(object sender, RoutedEventArgs e)
        {
            OperationNum("=");
            result1.Text = result1num.ToString();
        }
        //清除操作
        private void del_Click_1(object sender, RoutedEventArgs e)
        {
            result1.Text = "0";
            gongshi.Text = "";
            anxiazhi = "";
            result1num = 0.0;
        }
        //退格
        private void c_Click_1(object sender, RoutedEventArgs e)
        {
            //获取字符串长度
            int le = result1.Text.Length;
            int le2 = gongshi.Text.Length;
            if (le > 1 && le2 > 1)
            {
                result1.Text = result1.Text.Substring(0, le - 1);
                gongshi.Text = gongshi.Text.Substring(0, le2 - 1);
            }
        }
    }
}
