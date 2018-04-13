// TODO:7 добавляем DataContext для View и создаем UI
using System.Windows;

namespace SalesStatistics {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
