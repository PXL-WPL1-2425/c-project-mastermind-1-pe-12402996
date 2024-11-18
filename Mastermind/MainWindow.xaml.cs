using System.Printing;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace C_mastermindSprint1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {                
        List<string> colors = new List<string> { "Red", "Yellow", "Orange", "White", "Green", "Blue" };
        private List<string> secretCode = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            var randomCode = new Random();

            for (int i = 0; i < 4; i++)
            {
                secretCode.Add(colors[randomCode.Next(colors.Count)]);

            }
            this.Title = "Secret code: " + string.Join(", ", secretCode);
        }
        private DispatcherTimer timer = new DispatcherTimer();

        private void StartCountDown(object? sender, EventArgs e)
        {
            TimeSpan interval = new TimeSpan(0, 0, 1);

            timerTextBox.Text = interval.ToString();
        }

        private void StopCountDown(object? sender, EventArgs e)
        {
            checkButton_Click();
            timer.Stop();
        }

        private void ComboBoxColour_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            if (sender == comboBoxColour1 && comboBoxColour1.SelectedItem != null)
            {
                switch (comboBoxColour1.SelectedIndex)
                {
                    case 0:
                        labelColorOne.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 1:
                        labelColorOne.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 2:
                        labelColorOne.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case 3:
                        labelColorOne.Background = new SolidColorBrush(Colors.White);
                        break;
                    case 4:
                        labelColorOne.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 5:
                        labelColorOne.Background = new SolidColorBrush(Colors.Blue);
                        break;
                }
            }
            if (sender == comboBoxColour2 && comboBoxColour2.SelectedItem != null)
            {
                switch (comboBoxColour2.SelectedIndex)
                {
                    case 0:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 1:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 2:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case 3:
                        labelColorTwo.Background = new SolidColorBrush(Colors.White);
                        break;
                    case 4:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 5:
                        labelColorTwo.Background = new SolidColorBrush(Colors.Blue);
                        break;
                }
            }
            if (sender == comboBoxColour3 && comboBoxColour3.SelectedItem != null)
            {
                switch (comboBoxColour3.SelectedIndex)
                {
                    case 0:
                        labelColorThree.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 1:
                        labelColorThree.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 2:
                        labelColorThree.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case 3:
                        labelColorThree.Background = new SolidColorBrush(Colors.White);
                        break;
                    case 4:
                        labelColorThree.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 5:
                        labelColorThree.Background = new SolidColorBrush(Colors.Blue);
                        break;

                }
            }
            if (sender == comboBoxColour4 && comboBoxColour4.SelectedItem != null)
            {
                switch (comboBoxColour4.SelectedIndex)
                {
                    case 0:
                        labelColorFour.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 1:
                        labelColorFour.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 2:
                        labelColorFour.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case 3:
                        labelColorFour.Background = new SolidColorBrush(Colors.White);
                        break;
                    case 4:
                        labelColorFour.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case 5:
                        labelColorFour.Background = new SolidColorBrush(Colors.Blue);
                        break;
                }

            }
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            string checkColor1 = comboBoxColour1.Text;
            string checkColor2 = comboBoxColour2.Text;
            string checkColor3 = comboBoxColour3.Text;
            string checkColor4 = comboBoxColour4.Text;
            List<string> inputColor = new List<string> { checkColor1, checkColor2, checkColor3, checkColor4 };
            
            for(int i = 0; i < 4; i++)
            {
                Label checkColors = null;

                switch (i)
                {
                    case 0: checkColors = labelColorOne;
                        break;
                    case 1: checkColors = labelColorTwo;
                        break;
                    case 2: checkColors = labelColorThree;
                        break;
                    case 3: checkColors = labelColorFour;
                        break;
                }

                if (secretCode[i] == inputColor[i])
                {
                    checkColors.BorderBrush = Brushes.DarkRed;
                    checkColors.BorderThickness = new Thickness(7);                                       
                }
                else if (secretCode.Contains(inputColor[i]))
                {
                    checkColors.BorderBrush = Brushes.Wheat;
                    checkColors.BorderThickness = new Thickness(7);
                }
                else
                {
                    checkColors.BorderBrush = Brushes.Transparent;
                    checkColors.BorderThickness = new Thickness(7);
                }
            }

            int countAttempts = 0;
            int guessAttempts = 0;

            while (guessAttempts == countAttempts)
            {
                guessAttempts++;
                countAttempts++;
                this.Title = $"Poging: " + countAttempts;
                                
            }
        }


        private void toggleDebug(object sender, KeyEventArgs e)
        {
            string showGeneratedCode = this.Title;
            if ((e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl) && (e.Key == Key.F12))

            {
                generatedCodeTextBox.Text = showGeneratedCode;
            }
        }


    }
}


     
    