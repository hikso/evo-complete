using EVO_PV.Models.BusinessObjects;
using EVO_PV.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.ViewModels
{
    public class VMArticleSelectedInfo : NotifyPropertyChanged
    {
        MainWindow PrincipalScreen;
        private BOArticleReceive articleSelected { get; set; }
        public VMArticleSelectedInfo(MainWindow PrincipalScreen, BOArticleReceive bOArticleReceive)
        {
            this.PrincipalScreen = PrincipalScreen;
            this.ArticleSelected = bOArticleReceive;
        }


        public BOArticleReceive ArticleSelected
        {
            get { return articleSelected; }

            set
            {
                this.articleSelected = value;
                this.OnPropertyChanged("ArticleSelected");
            }
        }
    }
}
