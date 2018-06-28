using System.Reactive.Disposables;
using ReactiveUI;

namespace RxUiSplunk
{
    // Designer chokes on generic classes
    public abstract class InceptionOuterViewBase : ReactiveUserControl<InceptionOuterViewModel> { }

    public partial class InceptionOuterView : InceptionOuterViewBase
    {
        public InceptionOuterView()
        {
            InitializeComponent();

            this
                .WhenActivated(
                    disposables =>
                    {
                        this
                            .Bind(ViewModel, vm => vm.Greeting, v => v.Message.Text)
                            .DisposeWith(disposables);

                        this
                            .Bind(ViewModel, vm => vm.InceptionInnerViewModel, v => v.InnerHost.ViewModel)
                            .DisposeWith(disposables);
                    });
        }
    }
}
