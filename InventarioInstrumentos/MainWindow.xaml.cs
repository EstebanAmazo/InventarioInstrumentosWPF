using InventarioInstrumentos.DaoImpl;
using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace InventarioInstrumentos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InstrumentoDAO instrumentoDAO = new InstrumentoDAO();


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

            //instrumentosDataGrid.ItemsSource = instrumentos;
            instrumentosDataGrid.ItemsSource = instrumentoDAO.ObtenerTodos();


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
            // Obtener el botón que disparó el evento
            Button btnEliminar = sender as Button;

    
            DataGridRow fila = FindAncestor<DataGridRow>(btnEliminar);

            // Obtener el valor de la celda "id"
            int id = ((Instrumento)fila.Item).Id;



            instrumentoDAO.Eliminar(id);
            instrumentosDataGrid.ItemsSource = instrumentoDAO.ObtenerTodos();

        }

        private static T FindAncestor<T>(DependencyObject current)
        where T : DependencyObject
        {
            do
            {
                if (current is T parent)
                {
                    return parent;
                }
                current = VisualTreeHelper.GetParent(current);
            } while (current != null);
            return null;
        }

        private void instrumentosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
