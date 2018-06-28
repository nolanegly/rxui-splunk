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

        private ReactiveObject _currentViewModel;

        public ReactiveObject CurrentViewModel
        {
            get => _currentViewModel;
            set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
        }

        public ReactiveCommand<Unit, Unit> NavigateHomeCommand { get; }
        public ReactiveCommand<Unit, Unit> NavigateToTabsOnOneScreenCommand { get; }

        public ShellViewModel()
        {
            NavigateHomeCommand = ReactiveCommand.Create(NavigateToHomeScreen);
            NavigateToTabsOnOneScreenCommand = ReactiveCommand.Create(NavigateToTabsOnOneScreen);
        }

        private void NavigateToHomeScreen()
        {
            CurrentViewModel = null;
        }

        private void NavigateToTabsOnOneScreen()
        {
            CurrentViewModel = new TabsOnOneScreenViewModel();
        }
    }
}