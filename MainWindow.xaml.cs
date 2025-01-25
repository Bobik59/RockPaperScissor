using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace RockPaperScissor
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private string[] gameElements = { "Rock", "Paper", "Scissors" };
        public MainWindow()
        {
            InitializeComponent();
            InitializeGameUI();
        }

        private void InitializeGameUI()
        {
            // Main Grid Setup
            var mainGrid = new Grid { Margin = new Thickness(10) };

            // Define rows and columns
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Bot's choice
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) }); // Buttons
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Result

            // Bot's choice display (image and text)
            var botChoiceStackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var botChoiceImage = new Image
            {
                Name = "BotChoiceImage",
                Height = 100,
                Visibility = Visibility.Hidden
            };

            var botChoiceText = new TextBlock
            {
                Name = "BotChoiceText",
                Text = "Bot's Choice: ",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            botChoiceStackPanel.Children.Add(botChoiceImage);
            botChoiceStackPanel.Children.Add(botChoiceText);

            mainGrid.Children.Add(botChoiceStackPanel);
            Grid.SetRow(botChoiceStackPanel, 0);

            // Buttons
            var buttonsGrid = new UniformGrid { Columns = 3, HorizontalAlignment = HorizontalAlignment.Center };

            foreach (var element in gameElements)
            {
                var button = new Button
                {
                    Content = new Image
                    {
                        Source = new BitmapImage(new Uri($"C:\\Users\\User\\source\\repos\\RockPaperScissor\\Images\\{element}.png")),
                        Height = 100
                    },
                    Tag = element
                };
                button.Click += OnPlayerChoice;
                buttonsGrid.Children.Add(button);
            }

            mainGrid.Children.Add(buttonsGrid);
            Grid.SetRow(buttonsGrid, 1);

            // Result display
            var resultText = new TextBlock
            {
                Name = "ResultText",
                Text = "Result: ",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            mainGrid.Children.Add(resultText);
            Grid.SetRow(resultText, 2);

            // Set the grid as the content of the window
            this.Content = mainGrid;
        }

        private void OnPlayerChoice(object sender, RoutedEventArgs e)
        {
            var playerChoice = (string)((Button)sender).Tag;
            var botChoice = gameElements[random.Next(gameElements.Length)];

            var mainGrid = (Grid)this.Content;
            var botChoiceStackPanel = (StackPanel)mainGrid.Children[0];

            var botChoiceImage = (Image)botChoiceStackPanel.Children[0];
            botChoiceImage.Source = new BitmapImage(new Uri($"C:\\Users\\User\\source\\repos\\RockPaperScissor\\Images\\{element}.png"));
            botChoiceImage.Visibility = Visibility.Visible;

            var botChoiceText = (TextBlock)botChoiceStackPanel.Children[1];
            botChoiceText.Text = $"Bot's Choice: {botChoice}";

            var resultText = (TextBlock)mainGrid.Children[2];
        }
    }
}
