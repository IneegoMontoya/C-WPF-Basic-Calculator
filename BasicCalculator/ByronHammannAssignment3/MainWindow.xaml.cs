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

namespace ByronHammannAssignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       private bool isEmpty = true;
       private bool operatorChecked = false;
       private double x = 0;
       private double y = 0;
       private double z = 0;
       private double w;
       private char opValue;
       private bool decPoint = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void numClick(object sender, RoutedEventArgs e)
        {
            Button bttn = (Button)sender;
            if (isEmpty)
            {
                isEmpty = false;
                numDisplay.Text = bttn.Content.ToString();
                decPoint = false;
            }
            else numDisplay.Text = numDisplay.Text + bttn.Content.ToString(); 
        }

        private void opClick(object sender, RoutedEventArgs e)
        {
            Button bttn = (Button)sender;
            if (!isEmpty && !operatorChecked)
            {
                x = Convert.ToDouble(numDisplay.Text);
                opValue = Convert.ToChar(bttn.Content);
                operatorChecked = true;
                decPoint = false;
                isEmpty = true;
            }else if(operatorChecked)
            {
                y = Convert.ToDouble(numDisplay.Text);
                opValue = Convert.ToChar(bttn.Content);
                if (opValue == '+')
                {
                    w = (double)(x + y);
                    numDisplay.Text = Convert.ToString(w);
                    // numDisplay.Text = Convert.ToString((decimal)(x + y));
                }
                else if (opValue == '-')
                {
                    w = (double)(x - y);
                    numDisplay.Text = Convert.ToString(w);
                    // numDisplay.Text = Convert.ToString(x - y);
                }
                else if (opValue == 'X')
                {
                    w = (double)(x * y);
                    numDisplay.Text = Convert.ToString(w);
                    //numDisplay.Text = Convert.ToString((decimal)(x * y));
                }
                else if (opValue == '÷')
                {
                    if (y == 0)
                    {
                        numDisplay.Text = "Error";
                        isEmpty = true;
                    }
                    else
                    {
                        w = (double)(x / y);
                        numDisplay.Text = Convert.ToString(w);
                        //numDisplay.Text = Convert.ToString(x / y);
                    }

                }
                x = Convert.ToDouble(numDisplay.Text);
               // operatorChecked = false;
                decPoint = false;
                isEmpty = true;
            }

            
        }


        private void decClick(object sender, RoutedEventArgs e)
        {
            Button bttn = (Button)sender;
            if(numDisplay.Text.Contains("."))
            {
                decPoint = true;
            }
            if (isEmpty)
            {
                numDisplay.Text = bttn.Content.ToString();
                isEmpty = false;
                decPoint = true;
            }
            else if(!decPoint)
            {
              
                    numDisplay.Text = numDisplay.Text + bttn.Content.ToString();
                    decPoint = true;
                    isEmpty = false;
                
            }

        }

        private void memClick(object sender, RoutedEventArgs e)
        {
            Button bttn = (Button)sender;

            if(bttn.Content == "M+")
            {
                z = Convert.ToDouble(numDisplay.Text);
            }
            else if(bttn.Content == "M-")
            {
                z = 0;
            }
            else if(bttn.Content.ToString() == "MRC")
            {
                if (z != 0)
                {
                    //x = z;
                    numDisplay.Text = Convert.ToString(z);
                }
            }
        }

        private void clrClick(object sender, RoutedEventArgs e)
        {
            Button bttn = (Button)sender;
            if(bttn.Content.ToString() == "C")
            {
                numDisplay.Text = "";
                isEmpty = true;
            }
            if(bttn.Content.ToString() == "CA")
            {
                numDisplay.Text = "";
                isEmpty = true;
                operatorChecked = false;
                decPoint = false;
                x = 0;
                y = 0;
                z = 0;
            }
        }

        private void compute(object sender, RoutedEventArgs e)
        {
            if(!isEmpty && x != 0 && operatorChecked == true)
            {
                y = Convert.ToDouble(numDisplay.Text);
            }

            if(operatorChecked)
            {
                if(opValue == '+')
                {
                    w = (double)(x + y);
                    numDisplay.Text = Convert.ToString(w);
                   // numDisplay.Text = Convert.ToString((decimal)(x + y));
                }
                else if (opValue == '-')
                {
                    w = (double)(x - y);
                    numDisplay.Text = Convert.ToString(w);
                    // numDisplay.Text = Convert.ToString(x - y);
                }
                else if (opValue == 'X')
                {
                    w = (double)(x * y);
                    numDisplay.Text = Convert.ToString(w);
                    //numDisplay.Text = Convert.ToString((decimal)(x * y));
                }
                else if (opValue == '÷')
                {
                    if(y == 0)
                    {
                        numDisplay.Text = "Error";
                        isEmpty = true;
                    }
                    else
                    {
                        w = (double)(x / y);
                        numDisplay.Text = Convert.ToString(w);
                        //numDisplay.Text = Convert.ToString(x / y);
                    }
                    
                }

            }
            x = Convert.ToDouble(numDisplay.Text);
            operatorChecked = false;
            decPoint = false;
            isEmpty = true;


        }
    }



}
