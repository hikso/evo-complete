using EVO_PB.Models.BusinessObjects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EVO_PB.ControlsCustom
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 29-Ene/2020
    /// Descripción     : Clase implementa el poder obtener una colección de objetos seleccionados de un datagrid
    /// </summary>
    public class CustomArticlesDataGrid : DataGrid
    {
        public CustomArticlesDataGrid()
        {
            this.SelectionChanged += CustomDataGrid_SelectionChanged;
        }

        void CustomDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItemsList = new ObservableCollection<BOArticle>();
            foreach (BOArticle bOArticle in this.SelectedItems)
            {
                this.SelectedItemsList.Add(bOArticle);
            }          
        }
        #region SelectedItemsList

        public ObservableCollection<BOArticle> SelectedItemsList
        {
            get { return (ObservableCollection<BOArticle>)GetValue(SelectedItemsListProperty); }
            set { SetValue(SelectedItemsListProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
                DependencyProperty.Register("SelectedItemsList", typeof(ObservableCollection<BOArticle>), typeof(CustomArticlesDataGrid), new PropertyMetadata(null));

        #endregion
    }
}
