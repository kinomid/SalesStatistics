// TODO:7 добавляем DataContext для View и создаем интерфейс
using System.Windows;

namespace SalesStatistics {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
