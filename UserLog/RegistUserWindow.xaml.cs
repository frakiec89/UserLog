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
    /// Логика взаимодействия для RegistUserWindow.xaml
    /// </summary>
    public partial class RegistUserWindow : Window
    {
        public RegistUserWindow()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if ( tbPassword.Text != tbPasswordDoube.Text || 
                string.IsNullOrWhiteSpace(tbPassword.Text)||
                string.IsNullOrWhiteSpace(tbPasswordDoube.Text)
                )
            {
                MessageBox.Show("Разные пароли");
                return;
            }

            try
            {
                User user = new User(tbLogin.Text, tbPassword.Text, tbName.Text, dpBithDay.DisplayDate); // новый  юзер 
                UserController controller = new UserController();
                controller.AddUSer(user);
                MessageBox.Show("Ура,  пользователе добалвен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
