using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static TrabajoWPF.Secundaria;

namespace TrabajoWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Funcio> ListaReserva { get; set; }


        Secundaria ventana;

        public MainWindow()
        {
            InitializeComponent();
            ListaReserva = new ObservableCollection<Funcio>();
        }

        public void Acceder_config(object sender, RoutedEventArgs e)
        {
            if (ventana == null) { 

            if (ListaReserva.Count == 0) { ventana = new Secundaria(); } else { ventana = new Secundaria(ListaReserva); }

                ventana.CambioLienzo += vent_ActualizarGraficos;
                ventana.Guardar_graficas += copiaSeguridad;
                ventana.Show();
        }
        
        }

        private void copiaSeguridad(object sender, LienzoEventsArgs e)
        {
            ListaReserva = e.Func;
            lienzo.Children.Clear();

        }

        private void vent_ActualizarGraficos(object sender, LienzoEventsArgs e)
        {
            lienzo.Children.Clear();



            for (int y = 0; y < e.Func.Count; y++)
            {
  
                if (e.Func[y].estado)
                {

                    int numpuntos = (int)lienzo.ActualWidth;
                    Polyline funcion = new Polyline();
                    PointCollection puntos = new PointCollection();
                    Polyline funcion2 = new Polyline();
                    PointCollection puntos2 = new PointCollection();
                    bool bandera = true;

                    double xminreal = e.Func[y].ejex_Min, xmaxreal = e.Func[y].ejex_Max;
                    double yminreal = e.Func[y].ejey_Min, ymaxreal = e.Func[y].ejey_Max;
                    double xreal, yreal, xpant, ypant;
                    double xminpant = 0, xmaxpant = numpuntos;
                    double yminpant = 0, ymaxpant = (float)lienzo.ActualHeight;



                    Line linea = new Line();
                    linea.X1 = xminpant;
                    linea.X2 = xmaxpant;
                    double Zero = (yminpant - ymaxpant) * (0 - yminreal) / (ymaxreal - yminreal) + ymaxpant;
                    linea.Y1 = Zero;
                    linea.Y2 = Zero;
                    linea.StrokeThickness = 2;
                    linea.Stroke = System.Windows.Media.Brushes.Black;
                    lienzo.Children.Add(linea);

                    Line linea2 = new Line();
                    linea2.Y1 = yminpant;
                    linea2.Y2 = ymaxpant;
                    Zero = (xmaxpant - xminpant) * (0 - xminreal) / (xmaxreal - xminreal) + xminpant;
                    linea2.X1 = Zero;
                    linea2.X2 = Zero;
                    linea2.StrokeThickness = 2;
                    linea2.Stroke = System.Windows.Media.Brushes.Black;
                    lienzo.Children.Add(linea2);


                    bandera = true;
                    bool laMala = false;
                    for (int i = 0; i < numpuntos; i++)
                    {
                        bool f1 = true;
                        xreal = xminreal + i * (xmaxreal - xminreal) / numpuntos;
                        switch (e.Func[y].tipus) {
                            case "a*sen(b*x)":
                                yreal = e.Func[y].a * Math.Sin(xreal * e.Func[y].b);
                                break;
                            case "a*cos(b*x)":
                                yreal = e.Func[y].a * Math.Cos(xreal * e.Func[y].b);
                                break;
                            case "a*x^n":
                                yreal = e.Func[y].a * Math.Pow(xreal, e.Func[y].n);
                                break;
                            case "a*x+b":
                                yreal = e.Func[y].a *xreal + e.Func[y].b;
                                break;
                            case "a*x^2+b*x+c":
                                yreal = e.Func[y].a * Math.Pow(xreal, 2) + (e.Func[y].b * xreal) + e.Func[y].c;
                            break;
                            case "a/(b*x)":
                                laMala = true;
                                if (e.Func[y].b != 0 && xreal != 0)
                                {
                                    yreal = e.Func[y].a / (e.Func[y].b * xreal); 
                                }
                                else { bandera = false;f1 = false; yreal = -11111;}
                                break;
                            default:
                                yreal = 0;//nunca entrara aquí a si que no hay problema 
                                break;
                        }

                        if (laMala)//2 polylines para solucionar el problema del 0
                        {
                            if (f1)
                            {
                                xpant = (xmaxpant - xminpant) * (xreal - xminreal) / (xmaxreal - xminreal) + xminpant;
                                ypant = (yminpant - ymaxpant) * (yreal - yminreal) / (ymaxreal - yminreal) + ymaxpant;

                                Point pt = new Point(xpant, ypant);
                                if (bandera)
                                {
                                    puntos.Add(pt);
                                }
                                else
                                {
                                    puntos2.Add(pt);
                                }
                            }
                        }
                        else {
                            xpant = (xmaxpant - xminpant) * (xreal - xminreal) / (xmaxreal - xminreal) + xminpant;
                            ypant = (yminpant - ymaxpant) * (yreal - yminreal) / (ymaxreal - yminreal) + ymaxpant;

                            Point pt = new Point(xpant, ypant);
                            puntos.Add(pt);

                        }
                    }

                    funcion.Points = puntos;
                    funcion.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom(e.Func[y].colr));
                    funcion.StrokeThickness = 4;
                    lienzo.Children.Add(funcion);

                    funcion2.Points = puntos2;
                    funcion2.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom(e.Func[y].colr));
                    funcion2.StrokeThickness = 4;
                    lienzo.Children.Add(funcion2);
                    
                }
            }
        }
    }
}
