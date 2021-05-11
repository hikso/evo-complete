using EVO_PV.Utilities;
using System.Windows.Controls;

namespace EVO_PV.ViewModels
{
    public class VMSubItem : NotifyPropertyChanged
    {
        public VMSubItem(string name, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
        }

        public string Name { get; private set; }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged("IsSelected"); }
        }
        public UserControl Screen { get; private set; }
    }
}
