using Autofac;
using Fundacao.Views;
using System.Windows;

namespace Fundacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContentControl.Content = new SapataIsoladaView();

        }
    }
}
