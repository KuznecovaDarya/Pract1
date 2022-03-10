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
    public partial class NewOrder : Page
    {
        private Order _currentOrder = new Order();
        public NewOrder(Order selectedOrder)
        {
            InitializeComponent();
            if (selectedOrder != null)
                _currentOrder = selectedOrder;

            DataContext = _currentOrder;
            CustomerName.ItemsSource = ShopEntities.GetContext().Customer.ToList();
            ProductName.ItemsSource = ShopEntities.GetContext().Product.ToList();
            DeliverymanName.ItemsSource = ShopEntities.GetContext().Deliveryman.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();


            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentOrder.date_order)))
                errors.AppendLine("Укажите дату заказа");
            if (_currentOrder.Customer.Name == null) 
                errors.AppendLine("Выберите имя заказчика");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentOrder.Address)))
                errors.AppendLine("Укажите адрес заказа");
            if (_currentOrder.Product.Name == null)
                errors.AppendLine("Выберите товар");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentOrder.count_product)))
                errors.AppendLine("Укажите кол. товара");
            if (_currentOrder.Deliveryman.Name == null)
                errors.AppendLine("Выберите имя доставщика");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;

            }

            //if (_currentOrder.Id == 0)
            //{
            //    ShopEntities.GetContext().Order.Add(_currentOrder);
            //}

            try
            {
                ShopEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}

