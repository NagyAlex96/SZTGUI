using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _03_Ora.Model
{
    internal class MainWindowModel : ObservableObject
    {
        private double windowsWidth = SystemParameters.PrimaryScreenWidth / 1.5;
        public double WindowsWidth
        {
            get { return windowsWidth; }
            set { SetProperty(ref windowsWidth, value); }
        }

        private double windowsHeight = SystemParameters.PrimaryScreenHeight / 1.5;
        public double WindowsHeight
        {
            get { return windowsHeight; }
            set { SetProperty(ref windowsHeight, value); }
        }

        private int strength;
        public int Strength
        {
            get { return strength; }
            set { SetProperty(ref strength, value); }
        }        
        
        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set { SetProperty(ref vitality, value); }
        }        
        
        private int virtue;

        public int Virtue
        {
            get { return virtue; }
            set { SetProperty(ref virtue, value); }
        }



    }
}
