using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    /// <summary>
    /// Autor           : Hugo Sanchez
    /// Fecha de Creacón: 20-Mayo/2020
    /// Descripción     : Clase que construye la solución a páginas tipo pop para multiples instancias
    /// </summary>
    public class VMPopPages : NotifyPropertyChanged
    {
        #region Constructor
        public VMPopPages(MainWindow principalScreen)
        {
            this.PrincipalScreen = principalScreen;
            this.Pages = new ObservableCollection<ItemControForInvoice>();
            
            this.CmdClose = new RelayCommand<ItemControForInvoice>(Close);
            this.CmdOpenPage = new RelayCommand<ItemControForInvoice>(OpenPage);
        }
        #endregion
        #region Commands
        
        public ICommand CmdClose { get; }
        public ICommand CmdOpenPage { get; }

        #endregion
        #region Atributos públicos

        private MainWindow PrincipalScreen;

        public string Name { get; private set; }
        private ObservableCollection<ItemControForInvoice> pages;
        public ObservableCollection<ItemControForInvoice> Pages
        {
            get { return pages; }
            set { pages = value; OnPropertyChanged("Pages"); }
        }

        #endregion

        #region Metodos públicos
        public void Close(ItemControForInvoice itemControForInvoice)
        {
            this.Pages.Remove(itemControForInvoice);
            if (this.Pages.Count() > 0)
            {
                this.PrincipalScreen.ContentPage.Content = Pages.First().UCGenerateInvoice;
            }
            else
            {
                this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCDashboard;
            }

        }
        public void OpenPage(ItemControForInvoice itemControForInvoice)
        {
            this.PrincipalScreen.ContentPage.Content = itemControForInvoice.UCGenerateInvoice;
        }
        public void AddPage(ItemControForInvoice itemControForInvoice)
        {
            this.Pages.Add(itemControForInvoice);
        }
        #endregion
    }
}
