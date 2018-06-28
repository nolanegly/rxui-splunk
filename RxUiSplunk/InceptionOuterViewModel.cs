using ReactiveUI;

namespace RxUiSplunk
{
    public class InceptionOuterViewModel : ReactiveObject
    {
        private string _greeting;
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }
    }
}