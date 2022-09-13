using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _02_Ora
{
    /// <summary>
    /// Interaction logic for QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        private int remainingTime = 60;
        private readonly DispatcherTimer Timer = new DispatcherTimer();

        private Question _question;
        public QuestionWindow(Question question)
        {
            InitializeComponent();
            _question = question;
            this.question.Content = _question.question;

            UpLoadLabel();

            //this.answer01.Content = question.answerClasses[0];
            //answer01.MouseLeftButtonDown += AnswerCheck;

            //this.answer02.Content = question.answerClasses[1];
            //answer02.MouseLeftButtonDown += AnswerCheck;

            //this.answer03.Content = question.answerClasses[2];
            //answer03.MouseLeftButtonDown += AnswerCheck;

            //this.answer04.Content = question.answerClasses[3];
            //answer04.MouseLeftButtonDown += AnswerCheck;

            timerCounter();
        }

        private void AnswerCheck(object sender, MouseButtonEventArgs e)
        {
            var s = (sender as Label).Content;
            if (((sender as Label).Content as AnswerClass).isTrue)
            {
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }

        private void UpLoadLabel()
        {
            int j = 0;
            for (int i = 0; i < canvas.Children.Count; i++)
            {
                if (canvas.Children[i] is Label && (canvas.Children[i] as Label).Name != "question")
                {
                    (canvas.Children[i] as Label).Content = _question.answerClasses[j++];
                    (canvas.Children[i] as Label).MouseLeftButtonDown += AnswerCheck;
                }
            }
        }

        private void timerCounter()
        {
            this.counter.Text = remainingTime.ToString();

            Timer.Interval = TimeSpan.FromSeconds(1.0);
            Timer.Start();
            Timer.Tick += new EventHandler(delegate (object s, EventArgs a)
            {
                remainingTime += -1;
                this.counter.Text = remainingTime.ToString();
                if (remainingTime == 0)
                {
                    this.DialogResult = false;
                }
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan be szeretné zárni a lapot", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
