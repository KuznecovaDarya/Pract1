using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Shop2
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

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string password = Password.Text;
            for (int i = name.Length; i < 100; i++)
            {
                name += " ";
            }
            for (int i = password.Length; i < 15; i++)
            {
                password += " ";
            }
            int chet = 0;

            string table = "Worker"; //Имя таблицы
            string ssql = $"SELECT  * FROM {table} "; //Запрос 
            string connectionString = @"Data Source=.\MSSQLSERVER1;Initial Catalog=Shop;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                if (reader[1] + "" == name && reader[3] + "" == password)
                {
                    Window1 main = new Window1(reader[0] + "");
                    main.Show();
                    this.Close();
                    chet++;
                }
            }
            if (chet == 0) MessageBox.Show("Неверный логин или пароль!");
        }
    }
}
