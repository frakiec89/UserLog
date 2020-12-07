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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserLog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// обрабатывает  аутинтефикацию 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btIn_Click(object sender, RoutedEventArgs e)
        {
            UserController controller = new UserController();
            List<User> users = controller.Users; // ТУТ  НАШИ ПОЛЬЗОВАТЕЛИ 

            LogServerController logServerController = new LogServerController(); /// список  логов
            LogServer newLogServer;  // новый вход

            for (int i = 0; i < users.Count; i++)
            {
                if(
                    users[i].Password == tbPassword.Text &&
                    users[i].Login == tbLogin.Text 
                  )
                {

                    MessageBox.Show("Привет " + users[i].Name);

                    newLogServer = new LogServer(users[i], DateTime.Now); // Создали новый  вход

                    logServerController.Add(newLogServer); // записали  его  в  список ( в файл ) 

                    btLog.Visibility = Visibility.Visible; // Кнопку  видимой 

                    UsersWindow window = new UsersWindow();
                    window.Show();

                    return;
                }
            }

            newLogServer = new LogServer(tbLogin.Text, tbPassword.Text, DateTime.Now); /// неудачный вход
            logServerController.Add(newLogServer); // записали  его  в  список ( в файл ) 

            MessageBox.Show("неверный логин  или пароль");
        }

        /// <summary>
        /// Открывает окно  регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReg_Click(object sender, RoutedEventArgs e)
        {
            RegistUserWindow regist = new RegistUserWindow();
            regist.ShowDialog();
        }

        /// <summary>
        /// открывает  форму  с логами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLog_Click(object sender, RoutedEventArgs e)
        {
            LogsWindows windows = new LogsWindows();
            windows.ShowDialog();
        }

       
    }
}
