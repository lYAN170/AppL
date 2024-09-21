using System;
using System.IO;
using Microsoft.Maui.Controls;
using AppL.Models;
using AppL.Services;
using AppL.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppL.Views
{
    public partial class CategoriaListPage : ContentPage
    {
        private CategoriaController _categoriaController;

        public CategoriaListPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _categoriaController = new CategoriaController(dbPath);
            LoadCategorias();
        }

        private async void LoadCategorias()
        {
            var categorias = await _categoriaController.GetAllCategorias();
            CategoriasListView.ItemsSource = categorias;
        }

        private async void OnAddCategoryClicked(object sender, EventArgs e)
        {
            
        }

        private async void OnCategoryTapped(object sender, ItemTappedEventArgs e)
        {
            var categoria = (Categoria)e.Item;
            
        }
    }
}