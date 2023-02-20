using InventarioInstrumentos.Dao;
using InventarioInstrumentos.DaoImpl;
using InventarioInstrumentos.Modelos;
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

namespace InventarioInstrumentos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();







            //List<Persona> listaPersonas = new List<Persona>()
            //{
            //    new Persona() { Nombre = "Juan", Edad = 25, Ciudad = "Madrid" },
            //    new Persona() { Nombre = "Maria", Edad = 30, Ciudad = "Barcelona" },
            //    new Persona() { Nombre = "Pedro", Edad = 40, Ciudad = "Valencia" }
            //};

            //miTabla.ItemsSource = listaPersonas;

            InstrumentoDAO instrumentoDAO = new InstrumentoDAO();

            List<Instrumento> instrumentos = new List<Instrumento>()
            {
                instrumentoDAO.ObtenerPorId(4)
            };

            instrumentosDataGrid.ItemsSource = instrumentos;


            Console.WriteLine(instrumentoDAO.ObtenerNombreCategoria(3));



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener la fila seleccionada en el DataGrid
            var fila = (sender as FrameworkElement).DataContext;

            // Lógica para eliminar la fila seleccionada
            // ...
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
