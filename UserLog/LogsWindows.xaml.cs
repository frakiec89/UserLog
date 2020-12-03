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

namespace UserLog
{
    /// <summary>
    /// Логика взаимодействия для LogsWindows.xaml
    /// </summary>
    public partial class LogsWindows : Window
    {
        public LogsWindows()
        {
            InitializeComponent();
            this.Loaded += LogsWindows_Loaded;
        }

        private void LogsWindows_Loaded(object sender, RoutedEventArgs e)
        {
            LogServerController logServerController = new LogServerController();
            dgLogs.ItemsSource = logServerController.LogServers;

        }
    }
}
