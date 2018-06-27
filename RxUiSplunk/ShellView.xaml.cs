using System.Reactive.Disposables;
using ReactiveUI;

namespace RxUiSplunk
{
    // Designer chokes on generic classes
    public abstract class ShellViewBase : ReactiveUserControl<ShellViewModel> { }

    public partial class ShellView : ShellViewBase
    {
        public ShellView()
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
