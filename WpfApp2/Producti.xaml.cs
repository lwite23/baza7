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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Producti.xaml
    /// </summary>
    public partial class Producti : Page
    {
        public Producti()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            var content = AppData.db.Product.ToList();
            ProductQ.ItemsSource = content;
        }
    }
}
