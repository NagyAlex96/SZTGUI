using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02_Ora
{
    /*
     A 2. heti workshop célja
•	WPF ablakkezelésének megismerése
•	Reszponzív alkalmazás elkészítése a tartalommenedzserek kombinálásával
•	Adattárolási megoldás alkalmazása
Mindenki a padtársával együtt dolgozik! Cél a manual merge koncepció kipróbálása! Az egyik gépen kell bemutatni a megoldást, de párhuzamosan kell dolgozni. Az egyik ember a főablakot és az adatkezelést fejleszti le, a másik ember a felugró ablakot.
Készítsetek egy olyan grafikus felületű WPF alkalmazást, amelyben kvízjátékot lehet játszani! 
A játékmezőn megjelennek a lefordított lapok. Minden lap hátán ugyanaz az ikon legyen. A lap felfordítása után megjelenik a kérdés és a 4 válaszlehetőség egy új ablakban.
Elindul egy visszaszámláló 60-ról és amikor 0-hoz ér, akkor bezáródik az ablak és a válasz rossz lesz.
Hogyha a visszaszámlálás előtt rákattintunk az egyik válaszlehetőségre, akkor bezáródik az ablak. Attól függően, hogy jó vagy rossz volt a válasz, a kártyalap hátulja piros vagy zöld keretet kap és többé nem felfordítható.
Ha csak bezárjuk az ablakot, az olyan, mintha lejárt volna a visszaszámláló! Ám ekkor kérdezze meg az alkalmazás, hogy biztosan be szeretnénk-e zárni.

     
     
     */
    public partial class MainWindow : Window
    {
        private List<Question> questionList = new List<Question>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var read = File.ReadAllLines("kerdesek.txt");
            
            foreach (var item in read)
            {
                var sor = item.Split("#");
                Question question = new Question(sor[0]);

                for (int i = 1; i < sor.Length; i++)
                {
                    var temp = sor[i].Split("@");
                    question.answerClasses.Add(new AnswerClass( temp[0], temp[1].ToLower() == "true" ? true : false));
                }

                questionList.Add(question);
            }

            questionList.ForEach(t =>
            {
                Label l = new Label();
                l.Tag = t;
                l.Background = Brushes.LightBlue;
                l.Margin = new Thickness(20);
                l.Width = this.ActualWidth / 4;
                l.Height = this.ActualHeight / 4;
                wrapPanelWindows.Children.Add(l);

                l.MouseLeftButtonDown += L_MouseLeftButtonDown;
            });
        }

        private void L_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label l = (sender as Label);
            Question question = (Question)(l.Tag);

            QuestionWindow qwindow = new QuestionWindow(question);
            
            if (qwindow.ShowDialog() == true)
            {
                l.Background = Brushes.LightGreen;
                l.IsEnabled = false;
            }
            else
            {
                l.Background = Brushes.Red;
                l.IsEnabled = false;
            }
        
        }
    }
    public class Question
    {
        public string question;
        public List<AnswerClass> answerClasses;

        public Question(string question)
        {
            this.question = question;
            this.answerClasses = new List<AnswerClass>();
        }
    }

    public class AnswerClass
    {
        public string Answer { get; private set; }
        public bool isTrue { get; private set; }

        public AnswerClass(string answer, bool isTrue)
        {
            this.Answer = answer;
            this.isTrue = isTrue;
        }

        public override string ToString()
        {
            return this.Answer;
        }
    }
}
