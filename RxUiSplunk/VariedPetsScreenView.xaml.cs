using System.Reactive.Disposables;
using ReactiveUI;

namespace RxUiSplunk
{
    // Designer chokes on generic classes
    public abstract class VariedPetsScreenViewBase : ReactiveUserControl<VariedPetsViewModel> { }

    public partial class VariedPetsScreenView : VariedPetsScreenViewBase
    {
        public VariedPetsScreenView()
        {
            InitializeComponent();

            this
                .WhenActivated(
                    disposables =>
                    {
                        // set contents of listbox
                        this
                            .OneWayBind(ViewModel, vm => vm.Pets, v => v.PetsListBox.ItemsSource)
                            .DisposeWith(disposables);

                        // changes the viewmodel property when user changes the selected item
                        this
                            .Bind(ViewModel, vm => vm.SelectedPet, v => v.PetsListBox.SelectedItem)
                            .DisposeWith(disposables);

                        // change the displayed view and viewmodel in the pet host when the selection changes
                        this
                            .OneWayBind(ViewModel, vm => vm.SelectedPet, v => v.selectedPetHost.ViewModel)
                            .DisposeWith(disposables);
                    });
        }
    }
}
