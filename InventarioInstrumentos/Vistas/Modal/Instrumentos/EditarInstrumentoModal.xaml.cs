﻿using InventarioInstrumentos.DaoImpl;
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
using System.Windows.Shapes;

namespace InventarioInstrumentos.Vistas.Modal
{
    /// <summary>
    /// Interaction logic for EditarInstrumentoModal.xaml
    /// </summary>
    public partial class EditarInstrumentoModal : Window
    {
        InstrumentoDAO instrumentoDAO = new InstrumentoDAO();
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        TipoInstrumentoDAO tipoInstrumentoDAO = new TipoInstrumentoDAO();
        MarcaDAO marcaDAO = new MarcaDAO();

        private int idInstrumento;
        private int idCategoria = 0;
        private int idMarca = 0;
        private int idTipo = 0;

        private Gama gama;
        private Estado estado;


        public EditarInstrumentoModal(int idInstrumento)
        {
            InitializeComponent();
            this.idInstrumento = idInstrumento;


            CategoriaComboBox.DisplayMemberPath = "NombreCategoria";
            CategoriaComboBox.SelectedValuePath = "Id";
            CategoriaComboBox.ItemsSource = categoriaDAO.ObtenerTodos();

            Instrumento instrumentoExistente = instrumentoDAO.ObtenerPorId(idInstrumento);
            SerialTextBox.Text = instrumentoExistente.Serial;
            ModeloTextBox.Text = instrumentoExistente.Modelo;
            StockTextBox.Text =  instrumentoExistente.Stock.ToString();
            PrecioTextBox.Text = instrumentoExistente.Precio.ToString();

            GamaComboBox.SelectedItem = instrumentoExistente.Gama.ToString();
            EstadoComboBox.SelectedItem = instrumentoExistente.Estado.ToString();



            TipoComboBox.DisplayMemberPath = "NombreInstrumento";
            TipoComboBox.SelectedValuePath = "Id";
            TipoComboBox.ItemsSource = tipoInstrumentoDAO.ObtenerTodos();

            MarcaComboBox.DisplayMemberPath = "NombreMarca";
            MarcaComboBox.SelectedValuePath = "Id";
            MarcaComboBox.ItemsSource = marcaDAO.ObtenerTodos();

            GamaComboBox.ItemsSource = Enum.GetNames(typeof(Gama));
            EstadoComboBox.ItemsSource = Enum.GetNames(typeof(Estado));

        

        }

        private void ActualizarIntrumentoBtn(object sender, RoutedEventArgs e)
        {
            Instrumento instrumento = new Instrumento()
            {
                Serial = SerialTextBox.Text,
                Modelo = ModeloTextBox.Text,
                Stock = int.Parse(StockTextBox.Text),
                Precio = decimal.Parse(PrecioTextBox.Text),
                FechaIngreso = FechaDatePicker.SelectedDate.Value,
                Categoria = new Categoria()
                {
                    Id = idCategoria,
                },
                Marca = new Marca()
                {
                    Id = idMarca,
                },
                TipoInstrumento = new TipoInstrumento()
                {
                    Id = idTipo,
                },
                Estado = estado,
                Gama = gama

            };

            instrumentoDAO.Actualizar(idInstrumento, instrumento);
            MessageBox.Show("Instrumento actualizado correctamente");
            this.Close();

        }

        private void CategoriaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categoria categoriaSeleccionada = (Categoria)CategoriaComboBox.SelectedItem;
            idCategoria = categoriaSeleccionada.Id;
        }

        private void MarcaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Marca marcaSeleccionada = (Marca)MarcaComboBox.SelectedItem;
            idMarca = marcaSeleccionada.Id;
        }

        private void TipoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipoInstrumento tipoSeleccionado = (TipoInstrumento)TipoComboBox.SelectedItem;
            idTipo = tipoSeleccionado.Id;
        }

        private void GamaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            gama = (Gama)Enum.Parse(typeof(Gama), GamaComboBox.SelectedItem.ToString());
        }

        private void EstadoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            estado = (Estado)Enum.Parse(typeof(Estado), EstadoComboBox.SelectedItem.ToString());

        }
    }
}