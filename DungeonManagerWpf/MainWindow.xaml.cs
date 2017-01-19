using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace DungeonManagerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Settings.LoadSettings();
            Settings.MainWIndow = this;

            RefreshCharacters();
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Button_Click(sender, e);
            }
            else
                DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Maximized)
                WindowState = System.Windows.WindowState.Normal;
            else WindowState = System.Windows.WindowState.Maximized;
        }


        public void RefreshCharacters()
        {
            CharacterDataGrid.ItemsSource = null;
            CharacterDataGrid.Items.Clear();
            CharacterDataGrid.ItemsSource = Settings.Characters.OrderBy(c => c._sortOrder);
            CharacterDataGrid.UnselectAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //RefreshCharacters();
        }

        private void CharacterDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CharacterDataGrid.SelectedIndex != -1)
            {
                Character c = (Character)CharacterDataGrid.SelectedItem;
                CharacterWindow cw = new CharacterWindow(c);
                cw.Closed += CharacterWindow_Closed;
                cw.Show();
                //MessageBox.Show(c.Name);
            }
        }

        private void CharacterDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((e.PropertyName == "_guid") || 
                (e.PropertyName == "HitPoints") ||
                (e.PropertyName == "ProficiencyBonus") ||
                (e.PropertyName == "SpellAttackModifier") ||
                (e.PropertyName == "_sortOrder") ||
                (e.PropertyName == "ExperiencePoints")
                )
                e.Cancel = true;

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((CharacterDataGrid.SelectedIndex != -1) && (CharacterDataGrid.SelectedIndex != CharacterDataGrid.Items.Count - 1))
            {

                Character currentChar = (Character)CharacterDataGrid.SelectedItem;
                var previousChar = (Character)CharacterDataGrid.Items[CharacterDataGrid.SelectedIndex + 1];
                int tempSort = currentChar._sortOrder;
                currentChar._sortOrder = previousChar._sortOrder;
                previousChar._sortOrder = tempSort;
                RefreshCharacters();
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterDataGrid.SelectedIndex > 0 )
            {
                Character currentChar = (Character)CharacterDataGrid.SelectedItem;
                var previousChar = (Character)CharacterDataGrid.Items[CharacterDataGrid.SelectedIndex - 1];
                int tempSort = currentChar._sortOrder;
                currentChar._sortOrder = previousChar._sortOrder;
                previousChar._sortOrder = tempSort;
                RefreshCharacters();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var cw = new CharacterWindow(new Character());
            cw.Closed += CharacterWindow_Closed;
            cw.Show();
        }

        private void CharacterWindow_Closed(object sender, EventArgs e)
        {
            RefreshCharacters();
        }
    }

}
