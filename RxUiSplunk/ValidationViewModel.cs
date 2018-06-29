using ReactiveUI;

namespace RxUiSplunk
{
    public class ValidationViewModel : ReactiveObject
    {
        private string _tla;
        public string Tla
        {
            get => _tla;
            set => this.RaiseAndSetIfChanged(ref _tla, value);
        }
    }
}