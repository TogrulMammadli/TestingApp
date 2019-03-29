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

            CountingBadge.Badge = next < 99 ? (object)next : null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CountingBadge2.Badge == null || Equals(CountingBadge2.Badge, ""))
                CountingBadge2.Badge = 0;

            var next = int.Parse(CountingBadge2.Badge.ToString()) + 1;

            CountingBadge2.Badge = next < 99 ? (object)next : null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CountingBadge3.Badge == null || Equals(CountingBadge3.Badge, ""))
                CountingBadge3.Badge = 0;

            var next = int.Parse(CountingBadge3.Badge.ToString()) + 1;

            CountingBadge3.Badge = next < 99 ? (object)next : null;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (CountingBadge4.Badge == null || Equals(CountingBadge4.Badge, ""))
                CountingBadge4.Badge = 0;

            var next = int.Parse(CountingBadge4.Badge.ToString()) + 1;

            CountingBadge4.Badge = next < 99 ? (object)next : null;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (CountingBadge5.Badge == null || Equals(CountingBadge5.Badge, ""))
                CountingBadge5.Badge = 0;

            var next = int.Parse(CountingBadge5.Badge.ToString()) + 1;

            CountingBadge5.Badge = next < 99 ? (object)next : null;
        }
    }
}
