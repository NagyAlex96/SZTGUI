using _04_Ora.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Ora.ViewModel
{
    internal class MainWindowsVM : ObservableRecipient
    {
        public SuperHeroVM SuperHeroVM { get; private set; }
        public ObservableCollection<SuperHero> HeroesBarack { get; private set; }
        public ObservableCollection<SuperHero> HeroesArmy { get; private set; }

        public MainWindowsVM()
        {
            this.SuperHeroVM = new SuperHeroVM();
            this.HeroesBarack = new ObservableCollection<SuperHero>();
            this.HeroesArmy = new ObservableCollection<SuperHero>();


        }

        public IRelayCommand AddToArmyCommand{ get; private set; }

        private void AddToArmy()
        {

        }        
        
        public IRelayCommand AddToBarackCommand{ get; private set; }

        private void AddToBarack()
        {

        }

        private void SomeBasicHeroes()
        {
            this.HeroesArmy.Add(new SuperHero()
            {
                Name = "marine",
                Strength = 5,
                Pace = 4,
            });            
            
            this.HeroesArmy.Add(new SuperHero()
            {
                Name = "marine",
                Strength = 5,
                Pace = 4,
            });            
            
            this.HeroesArmy.Add(new SuperHero()
            {
                Name = "marine",
                Strength = 5,
                Pace = 4,
            });            
            
            this.HeroesArmy.Add(new SuperHero()
            {
                Name = "marine",
                Strength = 5,
                Pace = 4,
            });           
            
            this.HeroesArmy.Add(new SuperHero()
            {
                Name = "marine",
                Strength = 5,
                Pace = 4,
            });
        }

    }
}
