using System.Windows;

namespace WarThunderRandomGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainMenuLoaded;
        }

        private void MainMenuLoaded(object sender, RoutedEventArgs e)
        {
            this.CreatingWindow?.Close();
        }

        public Window CreatingWindow { get; set; }

        private void AirBattlesButton_Click(object sender, RoutedEventArgs e)
        {
            AirBattleGenerator battle = new AirBattleGenerator
            {
                CreatingWindow = this
            };

            battle.Show();
            
        }
    }
}