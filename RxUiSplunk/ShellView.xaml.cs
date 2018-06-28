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
                        // This wires the shellHost control to the current view model property.
                        // If views were registered correctly in Splat, the view will be hooked up automagically.
                        this.Bind(ViewModel, vm => vm.CurrentViewModel, v => v.shellHost.ViewModel)
                            .DisposeWith(disposables);

                        this
                            .Bind(ViewModel, vm => vm.Greeting, v => v.Message.Text)
                            .DisposeWith(disposables);

                        WireUpDemoButtons(disposables);
                    });
        }

        private void WireUpDemoButtons(CompositeDisposable disposables)
        {
            this
                .BindCommand(ViewModel, vm => vm.NavigateHomeCommand, v => v.HomeScreen)
                .DisposeWith(disposables);

            this
                .BindCommand(ViewModel, vm => vm.NavigateToTabsOnOneScreenCommand, v => v.TabsOnOneScreen)
                .DisposeWith(disposables);

            this
                .BindCommand(ViewModel, vm => vm.NavigateToVariedPetsScreenCommand, v => v.VariedPetsScreen)
                .DisposeWith(disposables);
        }
    }
}
