using Autofac;
using Fundacao.Startup;
using System.Windows;

namespace Fundacao
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //varr bootstraper = new Bootstrapper();

            //var container = bootstraper.Bootstrap();

            // var mainWindow = container.Resolve<MainWindow>();
            // mainWindow.Show();

            Bootstrapper.Start();

            var mainWindow = Bootstrapper.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
