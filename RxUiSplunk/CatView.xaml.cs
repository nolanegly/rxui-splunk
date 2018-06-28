using System.Reactive.Disposables;
using ReactiveUI;

namespace RxUiSplunk
{
    public abstract class CatViewBase : ReactiveUserControl<CatViewModel> { }

    public partial class CatView : CatViewBase
    {
        public CatView()
        {
            InitializeComponent();

            this.WhenActivated(
                disposables =>
                {
                    this.Bind(ViewModel, vm => vm.Name, v => v.Name.Text)
                        .DisposeWith(disposables);

                    this.Bind(ViewModel, vm => vm.LivesLeft, v => v.LivesLeft.Text)
                        .DisposeWith(disposables);
                });
        }
    }
}
