using Apollon.Domain.Models;
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

namespace Apollon.WPF.Views.Components
{
    /// <summary>
    /// Interaction logic for AddEditDetails.xaml
    /// </summary>
    public partial class AddEditDetails : UserControl
    {
        public AddEditDetails()
        {
            InitializeComponent();

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> competitions = new List<string>()
            {
                "Halle", "im Freien", "Feld", "3D"
            };
            ComboBox.ItemsSource = competitions;            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (ComboBox.SelectedIndex == 0)
            {
                CompetitionImage.Source = new BitmapImage(new Uri(@"D:\Projekte\Apollon\Apollon\Apollon.WPF\Images\TargetHall.png"));
            }
            if (ComboBox.SelectedIndex == 1)
            {
                CompetitionImage.Source = new BitmapImage(new Uri("D:\\Projekte\\Apollon\\Apollon\\Apollon.WPF\\Images\\TargetField.png"));
            }
            if (ComboBox.SelectedIndex == 2)
            {
                CompetitionImage.Source = new BitmapImage(new Uri("D:\\Projekte\\Apollon\\Apollon\\Apollon.WPF\\Images\\TargetOutdoor.png"));
            }
            if (ComboBox.SelectedIndex == 3)
            {
                CompetitionImage.Source = new BitmapImage(new Uri("D:\\Projekte\\Apollon\\Apollon\\Apollon.WPF\\Images\\3D.png"));
            }
        }
           
    }
       
}

