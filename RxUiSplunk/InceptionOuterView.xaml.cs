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
                            .Bind(this.ViewModel, x => x.Greeting, x => x.Message.Text)
                            .DisposeWith(disposables);
                    });
        }
    }
}
