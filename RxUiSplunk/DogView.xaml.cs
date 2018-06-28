using System.Reactive.Disposables;
using ReactiveUI;

namespace RxUiSplunk
{
    public abstract class DogViewBase : ReactiveUserControl<DogViewModel> { }

    public partial class DogView : DogViewBase
    {
        public DogView()
        {
            InitializeComponent();

            this.WhenActivated(
                disposables =>
                {
                    this.Bind(ViewModel, vm => vm.Name, v => v.Name.Text)
                        .DisposeWith(disposables);

                    this.Bind(ViewModel, vm => vm.FavoriteChewToy, v => v.FavoriteChewToy.Text)
                        .DisposeWith(disposables);
                });
        }
    }
}
