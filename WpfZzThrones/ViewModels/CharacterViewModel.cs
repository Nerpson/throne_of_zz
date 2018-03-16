using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfZzThrones.Models;
using WpfZzThrones.ViewModel;

namespace WpfZzThrones.ViewModels
{
    class CharacterViewModel : ViewModelBase
    {
        public CharacterViewModel()
        {
            var CharactersTask = HttpRequests.Instance.GetCharacters();

            Task.WaitAny(CharactersTask);

            Characters = CharactersTask.Result;
        }

        private CharacterDto Character { get; set; }

        private List<CharacterDto> Characters { get; set; }

        public string FirstName
        {
            get { return Character.FirstName; }
            set { Character.FirstName = value; OnPropertyChanged("FirstName"); }
        }

        public string LastName
        {
            get { return Character.LastName; }
            set { Character.LastName = value; OnPropertyChanged("LastName"); }
        }

        #region AddCommand

        private RelayCommand _addCommand;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
            HttpRequests.Instance.PostCharacter(Character);
        }
        #endregion
    }
}
