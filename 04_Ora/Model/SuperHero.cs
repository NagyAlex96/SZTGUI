using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Ora.Model
{
    internal class SuperHero : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private double strength;
        public double Strength
        {
            get { return strength; }
            set { SetProperty(ref strength, value); }
        }

        private double pace;
        public double Pace
        {
            get { return pace; }
            set { SetProperty(ref pace, value); }
        }



    }
}
