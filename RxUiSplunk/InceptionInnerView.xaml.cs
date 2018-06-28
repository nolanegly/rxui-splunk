using System.Reactive.Disposables;
using ReactiveUI;

namespace RxUiSplunk
{
    // Designer chokes on generic classes
    public abstract class InceptionInnerViewBase : ReactiveUserControl<InceptionInnerViewModel> { }

    public partial class InceptionInnerView : InceptionInnerViewBase
    {
        public InceptionInnerView()
        {
            InitializeComponent();

            this
                .WhenActivated(
                    disposables =>
                    {
                        this
                            .Bind(ViewModel, vm => vm.CustomMessage, v => v.CustomMessage.Text)
                            .DisposeWith(disposables);
                    });
        }
    }
}
