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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotlightWallpapers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // create controller object
        Controller controller = new Controller();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            // folder browser dialog
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
                textBoxBrowse.Text = fbd.SelectedPath;
        }

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            // check given path
            if (controller.CheckIfPathExists(textBoxBrowse.Text))
            {
                bool portraitWallpapers = false;

                // check portrait wallpapers
                if (checkBoxPortrait.IsChecked == true)
                    portraitWallpapers = true;

                if (controller.FileHandler(textBoxBrowse.Text, portraitWallpapers))
                    MessageBox.Show("Finished successfully!");
                else
                    MessageBox.Show("Error occured!");
            }
            else
            {
                MessageBox.Show("Please enter a correct destination path!");
            }
        }
    }
}
