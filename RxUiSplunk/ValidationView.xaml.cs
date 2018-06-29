using System.Reactive.Disposables;
using System.Windows.Controls;
using ReactiveUI;

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
                    });
        }
    }
}
