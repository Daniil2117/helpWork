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
    /// Логика взаимодействия для PageStaffInfo.xaml
    /// </summary>
    public partial class PageStaffInfo : Page
    {
        int check;
        public PageStaffInfo(int check)
        {
            InitializeComponent();
            this.check = check;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string[] fields = new string[4];
            if(check == 1)
            {
                fields = Staffs.GetDataUser(Pages.PageMain.selectionGridIndex);
                tbtName.Text = fields[0];
                tbtDr.Text = fields[1];
                tbtTel.Text = fields[2];
                tbtStaff.Text = fields[3];

                btnAdd.Content = "Обновить";
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
 
            if (check == 1)
            Staffs.UpdateStaff(tbtName.Text, tbtDr.Text, tbtTel.Text, tbtStaff.Text);
            else
            Staffs.AddNewStaff(tbtName.Text, tbtDr.Text, tbtTel.Text, tbtStaff.Text);
            
        }
    }
}
