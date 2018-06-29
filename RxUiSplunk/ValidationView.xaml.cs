using System.Reactive.Disposables;
using System.Windows.Controls;
using ReactiveUI;

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

// This namespace is critical, to get the right override of Subscribe on ViewModel.TlaIsValid


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
                        this
                            .Bind(ViewModel, vm => vm.Tla, v => v.Tla.Text)                            
                            .DisposeWith(disposables);

                        this
                            .WhenAnyValue(x => x.ViewModel.TlaIsValid)
                            .Subscribe(isValid => SetValidation(Tla, isValid))
                            .DisposeWith(disposables);


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
                return;
            }

            if (isValid)
            {
                Validation.ClearInvalid(bindingExpression);
                return;
            }

            var validationError = new ValidationError(new SplunkValidationRule("barf"), bindingExpression);
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
