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

        public InceptionInnerViewModel InceptionInnerViewModel { get; }

        public InceptionOuterViewModel(InceptionInnerViewModel inceptionInnerViewModel)
        {
            InceptionInnerViewModel = inceptionInnerViewModel;
            InceptionInnerViewModel.CustomMessage = "Default Custom Message from ctor";
        }
    }
}