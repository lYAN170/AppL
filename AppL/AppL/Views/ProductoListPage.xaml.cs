using System;
using System.IO;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using AppL.Models;
using AppL.Services;
using Microsoft.Maui.Controls;
using AppL.Controllers;


namespace AppL.Views
{
    public partial class ProductoListPage : ContentPage
    {
        private ProductoController _productoController;

        public ProductoListPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _productoController = new ProductoController(dbPath);
            LoadProductos();
        }

        private async void LoadProductos()
        {
            var productos = await _productoController.GetAllProductos();
            ProductosListView.ItemsSource = productos;
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductoEditPage());
        }

        private async void OnProductTapped(object sender, ItemTappedEventArgs e)
        {
            var producto = (Producto)e.Item;
            await Navigation.PushAsync(new ProductoEditPage());
        }
    }
}