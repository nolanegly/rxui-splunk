using ReactiveUI;

namespace RxUiSplunk
{
    public class InceptionInnerViewModel : ReactiveObject
    {
        private string _customMessage;
        public string CustomMessage
        {
            get => _customMessage;
            set => this.RaiseAndSetIfChanged(ref _customMessage, value);
        }
    }
}