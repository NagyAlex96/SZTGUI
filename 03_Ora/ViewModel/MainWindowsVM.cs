using _03_Ora.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Ora.ViewModel
{
    internal class MainWindowsVM : ObservableObject
    {
        public MainWindowModel mainWindowModel  { get; set; }

        public MainWindowsVM()
        {
            mainWindowModel = new MainWindowModel();


        }

        

    }
}
