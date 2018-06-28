using System.Collections.Generic;
using ReactiveUI;

namespace RxUiSplunk
{
    public class VariedPetsViewModel : ReactiveObject
    {
        public IList<PetViewModel> Pets { get; } // Not sure if this should be a reactive list of some type?

        private PetViewModel _selectedPet;
        public PetViewModel SelectedPet
        {
            get => this._selectedPet;
            set => this.RaiseAndSetIfChanged(ref this._selectedPet, value);
        }

        public VariedPetsViewModel()
        {
            Pets = new List<PetViewModel>(new PetViewModel[]
            {
                new CatViewModel("Elizabeth", 2),
                new DogViewModel("Fido", "slippers"),
                new CatViewModel("Ebony", 3),
                new DogViewModel("Igor", "tires")
            });
        }
    }

    public abstract class PetViewModel : ReactiveObject
    {
        public string Name { get; }

        protected PetViewModel(string name)
        {
            Name = name;
        }
    }

    public class CatViewModel : PetViewModel
    {
        public int LivesLeft { get; }

        public CatViewModel(string name, int livesLeft) : base(name)
        {
            LivesLeft = livesLeft;
        }
    }

    public class DogViewModel : PetViewModel
    {
        public string FavoriteChewToy { get; }

        public DogViewModel(string name, string favoriteChewToy) : base(name)
        {
            FavoriteChewToy = favoriteChewToy;
        }
    }
}