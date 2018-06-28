using ReactiveUI;

namespace RxUiSplunk
{
    public class TabsOnOneScreenViewModel : ReactiveObject
    {
        private string _greeting;
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        public TabsOnOneScreenViewModel()
        {
            Greeting = "Hi there, more to come at a later time!";
        }
    }
}