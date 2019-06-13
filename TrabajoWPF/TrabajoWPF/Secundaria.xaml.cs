using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace TrabajoWPF
{
    /// <summary>
    /// Lógica de interacción para Secundaria.xaml
    /// </summary>
    /// 


    public class LienzoEventsArgs : EventArgs
    {
        public ObservableCollection<Funcio> Func { get; set; }
    }

    public delegate void LienzoEventHandler(object sender, LienzoEventsArgs e);



    public partial class Secundaria : Window
    {

        public event LienzoEventHandler CambioLienzo;
        public event LienzoEventHandler Guardar_graficas;

        public void OnCambioLienzo(LienzoEventsArgs e)
        {
            if (CambioLienzo != null)
            {
                CambioLienzo(this, e);
            }

        }

        public void OnGuardar(LienzoEventsArgs e)
        {
            if (Guardar_graficas != null)
            {
                Guardar_graficas(this, e);
            }

        }

        public String colorElegido { get; set; }
         public ObservableCollection<Funcio> FuncList { get; set; }
        public Secundaria()
        {
            InitializeComponent();
            FuncList = new ObservableCollection<Funcio>();
            lista.ItemsSource = FuncList;
        }

        public Secundaria(ObservableCollection<Funcio> funcios)
        {
            InitializeComponent();
            FuncList = new ObservableCollection<Funcio>();
            FuncList = funcios;
            lista.ItemsSource = FuncList;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            Actual_ecu.Visibility = Visibility.Visible;
            {
                Actual_ecu.Content = b_1.Content;
                ec_1.Visibility = Visibility.Visible;
                ec_2.Visibility = Visibility.Visible;
                ec_3.Visibility = Visibility.Collapsed;
                ec_4.Visibility = Visibility.Collapsed;
            }
            if ((bool)b_2.IsChecked)
            {
                Actual_ecu.Content = b_2.Content;
                ec_1.Visibility = Visibility.Visible;
                ec_2.Visibility = Visibility.Visible;
                ec_3.Visibility = Visibility.Collapsed;
                ec_4.Visibility = Visibility.Collapsed;
            }
            if ((bool)b_3.IsChecked)
            { 
                Actual_ecu.Content = b_3.Content;
                ec_1.Visibility = Visibility.Visible;
                ec_2.Visibility = Visibility.Collapsed;
                ec_3.Visibility = Visibility.Collapsed;
                ec_4.Visibility = Visibility.Visible;
            }
            if ((bool)b_4.IsChecked)
            {
                Actual_ecu.Content = b_4.Content;
                ec_1.Visibility = Visibility.Visible;
                ec_2.Visibility = Visibility.Visible;
                ec_3.Visibility = Visibility.Collapsed;
                ec_4.Visibility = Visibility.Collapsed;
            }
            if ((bool)b_5.IsChecked)
            {
                Actual_ecu.Content = b_5.Content;
                ec_1.Visibility = Visibility.Visible;
                ec_2.Visibility = Visibility.Visible;
                ec_3.Visibility = Visibility.Visible;
                ec_4.Visibility = Visibility.Collapsed;
            }
            if ((bool)b_6.IsChecked)
            {
                Actual_ecu.Content = b_6.Content;
                ec_1.Visibility = Visibility.Visible;
                ec_2.Visibility = Visibility.Visible;
                ec_3.Visibility = Visibility.Collapsed;
                ec_4.Visibility = Visibility.Collapsed;
            }
        }

        private void NuevoObjeto(object sender, RoutedEventArgs e)
        {
            int VA = 0, VB = 0, VC = 0, VN = 0;
            int x;

            if ((bool)b_1.IsChecked || (bool)b_2.IsChecked || (bool)b_3.IsChecked || (bool)b_4.IsChecked || (bool)b_5.IsChecked || (bool)b_6.IsChecked)
            {
                bool flag = false;
                if (Var_a.IsVisible && (Var_a.Text.Length == 0))
                {
                    flag = true;
                }else{
                    if (Var_a.IsVisible && Int32.TryParse(Var_a.Text, out x))
                    {
                        VA = x;
                    }
                }
                if (Var_b.IsVisible && (Var_b.Text.Length == 0))
                {
                    flag = true;
                }else{
                    if (Var_b.IsVisible && Int32.TryParse(Var_b.Text, out x))
                    {
                        VB = x;
                    }
                }

                if (Var_c.IsVisible && (Var_c.Text.Length == 0))
                {
                    flag = true;
                }else{
                    if (Var_c.IsVisible && Int32.TryParse(Var_c.Text, out x))
                    {
                        VC = x;
                    }
                }

                if (Var_n.IsVisible && (Var_n.Text.Length == 0))
                {
                    flag = true;
                }else{
                    if (Var_n.IsVisible && Int32.TryParse(Var_n.Text, out x))
                    {
                        VN = x;
                    }
                }

                if (flag)
                {
                    string msg = "introduzca todas la variables a la función";
                    string titulo = "Error de lectura";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Warning;
                    System.Windows.MessageBox.Show(msg, titulo, botones, icono);
                }
                else if (colorElegido!=null)
                {

                    Funcio newFuncion = new Funcio((String)Actual_ecu.Content, textBox1.Text, colorElegido, VA, VB, VC, VN, Int32.Parse(eje2.Text), Int32.Parse(eje1.Text), Int32.Parse(eje4.Text), Int32.Parse(eje3.Text));
                    FuncList.Add(newFuncion);
                    Var_a.Text = ""; Var_b.Text = ""; Var_c.Text = ""; Var_n.Text = "";textBox1.Text = "";

                }
                else {
                    string msg = "Seleccione un color";
                    string titulo = "Color no seleccionado";
                    MessageBoxButton botones = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Warning;
                    System.Windows.MessageBox.Show(msg, titulo, botones, icono);
                }
            }

            else
            {

                string msg = "Seleccione un tipo de función";
                string titulo = "Error de lectura";
                MessageBoxButton botones = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Warning;
                System.Windows.MessageBox.Show(msg, titulo, botones, icono);
            }


        }

        private void SelColor_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult result = dlg.ShowDialog();
            colorElegido = System.Drawing.ColorTranslator.ToHtml(dlg.Color);
            probador.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorElegido));
        }

        private void Click_borrar(object sender, RoutedEventArgs e)
        {
            Button boton1 = (Button)sender;
            FuncList.Remove((Funcio)boton1.Tag);

            LienzoEventsArgs arg = new LienzoEventsArgs();
            arg.Func = FuncList;
            OnCambioLienzo(arg);

        }

        private void pecato(object sender, RoutedEventArgs e)
        {


            Button boton1 = (Button)sender;
            Funcio objeto = (Funcio)boton1.Tag;
            editar ventana1 = new editar(objeto.nom,objeto.colr,objeto.a,objeto.b,objeto.c,objeto.n,objeto.tipus,FuncList.IndexOf(objeto));

            ventana1.Owner = this;
            ventana1.Editar += GuardarEdicion;
            ventana1.ShowDialog();

        }
        
        private void GuardarEdicion(object sender, LaFuncionEventsArgs e)
        {
            FuncList[e.ind].a = e.argA;
            FuncList[e.ind].b = e.argB;
            FuncList[e.ind].c = e.argC;
            FuncList[e.ind].n = e.argN;
            FuncList[e.ind].colr = e.Colour;
 
            LienzoEventsArgs arg = new LienzoEventsArgs();
            arg.Func = FuncList;
            OnCambioLienzo(arg);
        }

 

        private void visible(object sender, RoutedEventArgs e)
        {
            ToggleButton b1 = (ToggleButton)sender;
            Funcio f1 = (Funcio)b1.Tag;
            f1.estado = true;

            LienzoEventsArgs arg = new LienzoEventsArgs();
            arg.Func = FuncList;
            OnCambioLienzo(arg);

        }

        private void oculto(object sender, RoutedEventArgs e)
        {
            ToggleButton b1 = (ToggleButton)sender;
            Funcio f1 = (Funcio)b1.Tag;
            f1.estado = false;

            LienzoEventsArgs arg = new LienzoEventsArgs();
            arg.Func = FuncList;
            OnCambioLienzo(arg);
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {

            string msg = "¿Quiere salir?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Graphics",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                string msg2 = "¿Quiere guardar las graficas?";
                MessageBoxResult result2 =
                  MessageBox.Show(
                    msg2,
                    "Graphics",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);


                if (result == MessageBoxResult.Yes)
                {
                    LienzoEventsArgs arg = new LienzoEventsArgs();
                    for(int y=0;y<FuncList.Count; y++)
                    {
                        FuncList[y].estado = false;
                    }
                    arg.Func = FuncList;
                    OnGuardar(arg);


                }

            }

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // hacer que no haga nada si no hay lista, llamar a actualizar lienzo y ver porqeu no funciona
            int x1,x2,x3,x4;
            if (eje1.Text.Length == 0 || eje2.Text.Length == 0 || eje3.Text.Length == 0 || eje4.Text.Length == 0)
            {
                string msg = "introduzca todos los datos";
                string titulo = "Datos incorrectos";
                MessageBoxButton botones = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Warning;
                System.Windows.MessageBox.Show(msg, titulo, botones, icono);
            }
            else if (!Int32.TryParse(eje1.Text, out x1) || !Int32.TryParse(eje2.Text, out x2) || !Int32.TryParse(eje3.Text, out x3) || !Int32.TryParse(eje4.Text, out x4))
            {
                string msg = "Mala sintaxis en los ejes";
                string titulo = "Datos incorrectos";
                MessageBoxButton botones = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Warning;
                System.Windows.MessageBox.Show(msg, titulo, botones, icono);
            }
            else {

                foreach (Funcio f in FuncList) {
                    f.ejex_Max = x2;
                    f.ejex_Min = x1;
                    f.ejey_Max = x4;
                    f.ejey_Min = x3;
                        
                }


            }

            LienzoEventsArgs arg = new LienzoEventsArgs();
            arg.Func = FuncList;
            OnCambioLienzo(arg);


        }
    }


}

