using System.Reactive.Disposables;
using System.Windows.Controls;
using ReactiveUI;

using System;
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
                            .Bind(ViewModel, vm => vm.TlaIsValid, v => v.IsValidState.Text)
                            .DisposeWith(disposables);

                        // this fails with System.InvalidOperationException: ''HasError' property was registered as read-only and cannot be modified without an authorization key.'
                        //this
                        //    .WhenAnyValue(x => x.ViewModel.TlaIsValid)
                        //    .Subscribe((x) => Tla.SetValue(Validation.HasErrorProperty, x));

                        this
                            .WhenAnyValue(x => x.ViewModel.TlaIsValid)
                            .Subscribe(isValid => SetValidation(Tla, isValid));
                    });
        }

        private void SetValidation(TextBox txtBox, bool isValid)
        {
            var bindingExpression = txtBox.GetBindingExpression(TextBox.TextProperty);

            if (bindingExpression == null)
            {
                return;
            }

            if (isValid)
            {
                Validation.ClearInvalid(bindingExpression);
                return;
            }

            var validationError = new ValidationError(new ExceptionValidationRule(), bindingExpression);
            Validation.MarkInvalid(bindingExpression, validationError);
        }
    }
}
