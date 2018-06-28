using System.Reactive.Disposables;
using ReactiveUI;

namespace RxUiSplunk
{
    // Designer chokes on generic classes
    public abstract class TabsOnOneScreenViewBase : ReactiveUserControl<TabsOnOneScreenViewModel> { }

    public partial class TabsOnOneScreenView : TabsOnOneScreenViewBase
    {
        public TabsOnOneScreenView()
        {
            InitializeComponent();

            this
                .WhenActivated(
                    disposables =>
                    {
                        this
                            .Bind(ViewModel, vm => vm.Greeting, v => v.Message.Text)
                            .DisposeWith(disposables);
                    });
        }
    }
}
