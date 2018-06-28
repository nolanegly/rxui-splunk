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
                            .Bind(ViewModel, vm => vm.Greeting, v => v.Message.Text)
                            .DisposeWith(disposables);

                        this
                            .BindCommand(ViewModel, vm => vm.NavigateToTabsOnOneScreenCommand, v => v.TabsOnOneScreen)
                            .DisposeWith(disposables);
                    });
        }
    }
}
