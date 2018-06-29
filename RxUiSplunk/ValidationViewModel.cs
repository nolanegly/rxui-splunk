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

        private readonly ObservableAsPropertyHelper<bool> _tlaIsValid;
        public bool TlaIsValid => _tlaIsValid.Value;

        public ValidationViewModel()
        {
            _tlaIsValid = this
                .WhenAnyValue(x => x.Tla, 
                    tla => !string.IsNullOrEmpty(tla) && tla.Length.Equals(3))
                .ToProperty(this, x => x.TlaIsValid);
        }
    }
}