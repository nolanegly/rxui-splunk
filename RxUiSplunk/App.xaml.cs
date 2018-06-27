using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using ReactiveUI;
using Splat;

namespace RxUiSplunk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DoSplatRegistrations();

            var vm = Locator.Current.GetService<ShellViewModel>();
            vm.Greeting = "Hello world!";

            App.Current.MainWindow = new MainWindow(vm);
            App.Current.MainWindow.Show();
        }

        private void DoSplatRegistrations()
        {
            var loc = Locator.CurrentMutable;

            // only registers views for use with viewmodels, viewmodels have to be registered separately
            loc.RegisterViewsForViewModels(Assembly.GetExecutingAssembly()); 

            loc.Register(() => new ShellViewModel(), typeof(ShellViewModel));
        }
    }
}
