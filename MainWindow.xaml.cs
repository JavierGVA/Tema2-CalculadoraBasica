using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema2_CalculadoraBasica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean checkOperando1 = false;
        Boolean checkOperando2 = false;
        
        public MainWindow()
        {
            
            InitializeComponent();          

        }
        private void LimpiarButton_Click(Object sender, RoutedEventArgs e)
        {
            toperando1.Text = string.Empty;
            toperando2.Text = string.Empty;
            toperador.Text = string.Empty;
            tresultado.Text = string.Empty;
            bcalcular.IsEnabled = false;
            checkOperando1 = false ;
            checkOperando2 = false ;
            
        }
        private  void CalcularButton_Click(Object sender, RoutedEventArgs e)
            
        {
            
            if (!double.TryParse(toperando1.Text, out _) || !double.TryParse(toperando2.Text, out _))
            {

                MessageBox.Show("¡Error, ingrese valores númericos!");
            }
            else
            {
                
                Calcular(int.Parse(toperando1.Text), int.Parse(toperando2.Text), toperador.Text, tresultado);
            }
        }
        private static void Calcular(double operadorUno, double operadorDos, string operando, TextBox tresultado)
        {
            switch(operando){

                case "-":
                    tresultado.Text = (operadorUno - operadorDos).ToString();
                    break;
                case "+":
                    tresultado.Text = (operadorUno + operadorDos).ToString();
                    break;
                case "*":
                    tresultado.Text = (operadorUno * operadorDos).ToString();
                    break;
                case "/":
                    tresultado.Text = (operadorUno / operadorDos).ToString();
                    break;
                
            }

        }
        private void toperando1_TextChanged(object  sender, TextChangedEventArgs e) {

            
            if (toperando1.Text != "")
                checkOperando1 = true;



        }
        private void toperando2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (toperando2.Text != "")
                checkOperando2 = true;

        }
        private void toperador_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (checkOperando1 == true && checkOperando2 == true)
            {
                if (toperador.Text == "")
                {
                    bcalcular.IsEnabled = false;
                }
                else if (toperador.Text == "-" ||
                    toperador.Text == "+" ||
                    toperador.Text == "*" ||
                    toperador.Text == "/")
                {
                    bcalcular.IsEnabled = true;
                }
            }

            else bcalcular.IsEnabled = false;
            
        }
    }
}
