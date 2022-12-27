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

namespace WpfApp1Rab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameClass.BodyFrame = FrameBody;
            FrameClass.BodyFrame.Navigate(new Pages.PageMain());
        }

        private void FrameBodyThr_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new Pages.PageStaffInfo(0));
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (Pages.PageMain.selectionGridIndex == -1)
                MessageBox.Show("Сотрудник не выбран, выберите сотрудника!");
            else
                FrameClass.BodyFrame.Navigate(new Pages.PageStaffInfo(1));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (Pages.PageMain.selectionGridIndex == -1)
                MessageBox.Show("Сотрудник не выбран, выберите сотрудника!");
            else
                Staffs.DeleteStaff();
        }
    }
}
