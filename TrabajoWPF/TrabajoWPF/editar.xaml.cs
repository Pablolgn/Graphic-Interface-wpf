using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TextBox = System.Windows.Controls.TextBox;

namespace TrabajoWPF
{
    /// <summary>
    /// Lógica de interacción para editar.xaml
    /// </summary>
    /// 



    public class LaFuncionEventsArgs : EventArgs
    {
        public String Colour { get; set; }
        public int ind { get; set; }
        public int argA { get; set; }
        public int argB { get; set; }
        public int argC { get; set; }
        public int argN { get; set; }

    }

    public delegate void LaFuncionEventHandler(object sender, LaFuncionEventsArgs e);

    public partial class editar : Window
    {

        public event LaFuncionEventHandler Editar;

        public void OnEditar(LaFuncionEventsArgs e)
        {
            if (Editar != null)
            {
                Editar(this, e);
            }

        }
        public String colorElegido { get; set; }
        public int index { get; set; }
        public int a_A { get; set; }
        public int a_B { get; set; }
        public int a_C { get; set; }
        public int a_N { get; set; }



        public editar()
        {
            InitializeComponent();
        }


        public editar(String nombre, String colr, int a, int b, int c, int n, String tipo,int i)
        {

            InitializeComponent();
            colorElegido = colr;
            Var_a.Text = a.ToString("0");
            Var_b.Text = b.ToString("0");
            Var_c.Text = c.ToString("0");
            Var_n.Text = n.ToString("0");
            index = i;
            ElNombre.Content = nombre;

            probador.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(colr));

            if (tipo=="a*sen(b*x)" || tipo == "a*cos(b*x)" || tipo== "a*x+b" || tipo== "a/(b*x)") { ec_1.Visibility = Visibility.Visible; ec_2.Visibility = Visibility.Visible; }
            if (tipo == "a*x^n") { ec_1.Visibility = Visibility.Visible; ec_4.Visibility = Visibility.Visible; }
            if (tipo == "a*x^2+b*x+c") { ec_1.Visibility = Visibility.Visible; ec_2.Visibility = Visibility.Visible; ec_3.Visibility = Visibility.Visible; }



        }


        private void B(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult result = dlg.ShowDialog();
            colorElegido = System.Drawing.ColorTranslator.ToHtml(dlg.Color);
            probador.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorElegido));
        }

        private void Solo_numeros(object sender, TextCompositionEventArgs e)
        {
            //se convierte a Ascci del la tecla presionada 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //verificamos que se encuentre en ese rango que son entre el 0 y el 9 
            if ((ascci >= 48 && ascci <= 57) || ascci == 45)
                e.Handled = false;
            else e.Handled = true;
        }


        private void C1(object sender, TextChangedEventArgs e)
        {
            int x;
            TextBox t1 = (TextBox)sender;
            if (Int32.TryParse(t1.Text, out x)) { a_A = x; };
        }
        private void C2(object sender, TextChangedEventArgs e)
        {
            int x1;
            TextBox t1 = (TextBox)sender;
            if (Int32.TryParse(t1.Text, out x1)) { a_B = x1; }
        }
        private void C3(object sender, TextChangedEventArgs e)
        {
            int x2;
            TextBox t1 = (TextBox)sender;
            if (Int32.TryParse(t1.Text, out x2)) { a_C = x2; };
        }
        private void C4(object sender, TextChangedEventArgs e)
        {
            int x3;
            TextBox t1 = (TextBox)sender;
            if (Int32.TryParse(t1.Text, out x3)) { a_N = x3; };
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirmar(object sender, RoutedEventArgs e)
        {

            LaFuncionEventsArgs arg = new LaFuncionEventsArgs();
            arg.argA = a_A;
            arg.argB = a_B;
            arg.argC = a_C;
            arg.argN = a_N;
            arg.Colour = colorElegido;
            arg.ind = index;
            OnEditar(arg);
            this.Close();
        }
    }
}
