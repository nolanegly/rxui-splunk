using System.Reactive.Disposables;
using System.Windows.Controls;
using ReactiveUI;
using System.Globalization;

using System; // This namespace is critical, to get the right override of Subscribe on ViewModel.TlaIsValid


namespace RxUiSplunk
{
    // Designer chokes on generic classes
    public abstract class ValidationViewBase : ReactiveUserControl<ValidationViewModel> { }

    public partial class ValidationView : ValidationViewBase
    {
        public ValidationView()
        {
            InitializeComponent();

            this
                .WhenActivated(
                    disposables =>
                    {
                        // basic vm to v binding
                        this
                            .Bind(ViewModel, vm => vm.Tla, v => v.Tla.Text)                            
                            .DisposeWith(disposables);

                        // react to TlaIsValid changing, letter by letter. Maybe overkill if only doing when losing focus, but possible.
                        this
                            .WhenAnyValue(x => x.ViewModel.TlaIsValid)
                            .Subscribe(isValid => SetValidation(Tla, ViewModel.TlaIsValid))
                            .DisposeWith(disposables);

                        // when textbox loses focus, evaluate validity. Doesn't seem to fire the converter on template though, not sure it's working?
                        Tla.Events().LostFocus
                            .Subscribe(e => SetValidation(Tla, ViewModel.TlaIsValid))
                            .DisposeWith(disposables);


                        // sanity check on value of TlaIsValid, not needed
                        this
                            .Bind(ViewModel, vm => vm.TlaIsValid, v => v.IsValidState.Text)
                            .DisposeWith(disposables);
                    });
        }

        private void SetValidation(TextBox txtBox, bool isValid)
        {
            var bindingExpression = txtBox.GetBindingExpression(TextBox.TagProperty);

            if (bindingExpression == null)
            {
                return; // Binding must be set, either in XAML or code, for the calls to Validation
            }

            if (isValid)
            {
                Validation.ClearInvalid(bindingExpression);
                return;
            }

            // Validate method on rule is never actually called since we are doing this out of the binding pipeline.
            var validationError = new ValidationError(new SplunkValidationRule("barf"), bindingExpression, $"{txtBox.Text} is invalid", null);
            Validation.MarkInvalid(bindingExpression, validationError);
        }
    }

    public class SplunkValidationRule : ValidationRule
    {
        public string ErrorMessage { get; }

        public SplunkValidationRule(string errorMessage)
        {
            ErrorMessage = errorMessage ?? "It's no good";
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(false, ErrorMessage);
        }
    }
}
