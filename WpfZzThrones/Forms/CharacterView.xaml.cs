using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfZzThrones.ViewModels;

namespace WpfZzThrones.Forms
{
    /// <summary>
    /// Logique d'interaction pour CharacterView.xaml
    /// </summary>
    public partial class CharacterView : Window
    {
        private CharacterViewModel _avm;

        public CharacterView()
        {
            InitializeComponent();
            Loaded += this.Window_Loaded;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialisation du viewModel

            _avm = new CharacterViewModel();
            ucCharacterEditor.DataContext = _avm;
            ucCharacterLister.DataContext = _avm;
        }
    }
}
