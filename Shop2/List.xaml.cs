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

namespace Shop2
{
    /// <summary>
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List : Page
    {
        public List()
        {
            InitializeComponent();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new NewOrder((sender as Button).DataContext as Order));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new NewOrder(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var orderForRemoving = DGOrder.SelectedItems.Cast<Order>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить слудующие {orderForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ShopEntities.GetContext().Order.RemoveRange(orderForRemoving);
                    ShopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGOrder.ItemsSource = ShopEntities.GetContext().Order.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ShopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGOrder.ItemsSource = ShopEntities.GetContext().Order.ToList();
            }
        }
    }
}
