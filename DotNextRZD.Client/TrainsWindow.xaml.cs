using System.Windows;
using DotNextRZD.Client.ViewModels;

namespace DotNextRZD.Client
{
    /// <summary>
    /// Interaction logic for TrainsWindow.xaml
    /// </summary>
    public partial class TrainsWindow : Window
    {
        public TrainsWindow()
        {
            InitializeComponent();
            DataContext = new TrainsViewModel();
        }
    }
}
