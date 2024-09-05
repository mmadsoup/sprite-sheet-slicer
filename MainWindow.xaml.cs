using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpriteSheetSlicer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int imageWidth;
        private int imageHeight;

        private int sliceWidth;
        private int sliceHeight;

        BitmapImage? bitmap;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                InitialDirectory = "c:\\",
                Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == true)
            {
                string selectedFileName = fileDialog.FileName;
                bitmap = new();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                spriteSheet.Source = bitmap;
                
                imageWidth = bitmap.PixelWidth; 
                imageHeight = bitmap.PixelHeight;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SpriteWidth_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (spriteSlicedWidth.Text == string.Empty)
            {
                test.Text = string.Empty;
            }

            if (!int.TryParse(spriteSlicedWidth.Text, out int number))
            {
                return;
            }

            sliceWidth = number;
            int cols =  imageWidth / sliceWidth;
           
            //test.Text = spriteSheet
            Line line = new()
            {
                X1 = 0,
                X2 = 100,
                Y1 = 0,
                Y2 = 10,
                Stroke = System.Windows.Media.Brushes.Black,
                StrokeThickness = 1
            };

            Grid.SetRow(line, 2);
            root.Children.Add(line);
        }

        private void SpriteHeight_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
