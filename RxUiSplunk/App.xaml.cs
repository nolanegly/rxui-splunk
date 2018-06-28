using System.Reflection;
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

            // Ensure Splat does not think it is in design mode or in a unit test runner (causing it to run slower)
            Splat.ModeDetector.OverrideModeDetector(ProductionModeDetector.Instance);

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
            //loc.Register(() => new TabsOnOneScreenViewModel(), typeof(TabsOnOneScreenViewModel));
        }
    }
}
