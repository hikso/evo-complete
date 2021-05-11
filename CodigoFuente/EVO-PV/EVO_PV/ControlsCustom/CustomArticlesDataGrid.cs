using EVO_PV.Models.BusinessObjects;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EVO_PV.ControlsCustom
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
            Type bOArticleType = new BOArticle().GetType();
            if (this.SelectedItem == null) return;
            if (this.SelectedItem.GetType() == bOArticleType)
            {
                SelectedItemsList = new ObservableCollection<BOArticle>();
                foreach (BOArticle bOArticle in this.SelectedItems)
                {
                    this.SelectedItemsList.Add(bOArticle);
                }
            }
            Type bOBillingArticleType = new BOBillingArticle().GetType();
            if (this.SelectedItem.GetType() == bOBillingArticleType)
            {
                SelectedItemsListBillingArticle = new ObservableCollection<BOBillingArticle>();
                foreach (BOBillingArticle bOBillingArticle in this.SelectedItems)
                {
                    this.SelectedItemsListBillingArticle.Add(bOBillingArticle);
                }
            }

        }
        #region SelectedItemsList

        public ObservableCollection<BOArticle> SelectedItemsList
        {
            get { return (ObservableCollection<BOArticle>)GetValue(SelectedItemsListProperty); }
            set { SetValue(SelectedItemsListProperty, value); }
        }

        public ObservableCollection<BOBillingArticle> SelectedItemsListBillingArticle
        {
            get { return (ObservableCollection<BOBillingArticle>)GetValue(SelectedItemsListPropertyForBOBillingArticle); }
            set { SetValue(SelectedItemsListPropertyForBOBillingArticle, value); }
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
                DependencyProperty.Register("SelectedItemsList", typeof(ObservableCollection<BOArticle>), typeof(CustomArticlesDataGrid), new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedItemsListPropertyForBOBillingArticle =
                DependencyProperty.Register("SelectedItemsListBillingArticle", typeof(ObservableCollection<BOBillingArticle>), typeof(CustomArticlesDataGrid), new PropertyMetadata(null));

        #endregion
    }
}
