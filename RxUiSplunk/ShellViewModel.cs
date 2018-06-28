using System.Reactive;
using System.Windows;
using ReactiveUI;

namespace RxUiSplunk
{
    public class ShellViewModel : ReactiveObject
    {
        private string _greeting;
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        public ReactiveCommand<Unit, Unit> NavigateToTabsOnOneScreenCommand { get; }

        public ShellViewModel()
        {
            NavigateToTabsOnOneScreenCommand = ReactiveCommand.Create(NavigateToTabsOnOneScreen);
        }

        private void NavigateToTabsOnOneScreen()
        {
            MessageBox.Show("Do the navigation here!");
        }
    }
}