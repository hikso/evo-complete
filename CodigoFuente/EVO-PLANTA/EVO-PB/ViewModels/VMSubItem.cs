using EVO_PB.Utilities;
using System.Windows.Controls;

namespace EVO_PB.ViewModels
{
    public class VMSubItem : NotifyPropertyChanged
    {
        public VMSubItem(string name, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
        }

        public string Name { get; private set; }
        public UserControl Screen { get; private set; }

    }
}
