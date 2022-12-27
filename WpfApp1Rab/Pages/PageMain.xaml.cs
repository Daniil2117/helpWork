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
using WpfApp1Rab.CLasses;

namespace WpfApp1Rab.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public static int selectionGridIndex = -1;

        List<Staffs> spisok = new List<Staffs>();

        public PageMain()
        {
            InitializeComponent();

            spisok.Add(new Staffs("Петров П.П.", "01.01.2001", "895647382931", "Директор"));
            spisok.Add(new Staffs("Сидоров П.П.", "01.01.2001", "895647382931", "Гл.бух"));
            spisok.Add(new Staffs("Иванов П.П.", "01.01.2001", "895647382931", "Менеджер"));
            spisok.Add(new Staffs("Куликов П.П.", "01.01.2001", "895647382931", "Менеджер"));

            DataGridInfo.ItemsSource = spisok;
        }

        private void DataGridInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionGridIndex = DataGridInfo.SelectedIndex;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridInfo.ItemsSource = SearchFam(tbxSearch.Text); 
        }

        List<Staffs> SearchFam(string textSearch)
        {
            List<Staffs> searchList = new List<Staffs>();

            foreach(Staffs s in spisok)
            {
                if (s.Name.ToLower().StartsWith(textSearch.ToLower()) || s.Staff.ToLower().StartsWith(textSearch.ToLower()) || s.Telephon.ToLower().StartsWith(textSearch.ToLower()))
                    searchList.Add(s);
            }
            return searchList;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            spisok = Staffs.LoadFromDB();
            DataGridInfo.ItemsSource = spisok;
        }
    }
}
