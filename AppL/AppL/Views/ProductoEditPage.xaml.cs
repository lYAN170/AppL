using System;
using System.Collections.Generic;
using System.IO;
using AppL.Controllers;
using AppL.Models;
using AppL.Services;
using Microsoft.Maui.Controls;

namespace AppL.Views
{
    public partial class ProductoEditPage : ContentPage
    {
        private ProductoController _productoController;

        public ProductoEditPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _productoController = new ProductoController(dbPath);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var producto = new Producto
            {
                Nombre = NombreEntry.Text,
                Precio = decimal.TryParse(PrecioEntry.Text, out var precio) ? precio : 0,
                CategoriaId = GetSelectedCategoriaId()
            };

            await _productoController.AddProducto(producto);
            await Navigation.PopAsync();
        }

        private int GetSelectedCategoriaId()
        {
            
            return 0; 
        }
    }
}