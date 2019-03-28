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

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for ChooseTestBlankPage.xaml
    /// </summary>
    public partial class ChooseTestBlankPage : Page
    {
        public ChooseTestBlankPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CountingBadge.Badge == null || Equals(CountingBadge.Badge, ""))
                CountingBadge.Badge = 0;

            var next = int.Parse(CountingBadge.Badge.ToString()) + 1;

            CountingBadge.Badge = next < 21 ? (object)next : null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
