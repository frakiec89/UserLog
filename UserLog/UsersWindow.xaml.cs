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
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();

            this.Loaded += UsersWindow_Loaded; // событие
        }

        private void UsersWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserController userControl = new UserController(); // подгружает  список  юзеров 

            cbxUser.ItemsSource = userControl.Users; /// Даем  список  объектов  комбобоксу   
            

        }
    }
}
