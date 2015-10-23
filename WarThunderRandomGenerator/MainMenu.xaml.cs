using System.Windows;

namespace WarThunderRandomGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AirBattlesButton_Click(object sender, RoutedEventArgs e)
        {
            AirBattles battle = new AirBattles();
            battle.CreatingWindow = this;
            battle.Show();
            
        }
    }
}