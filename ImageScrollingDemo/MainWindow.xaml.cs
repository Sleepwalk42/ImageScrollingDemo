using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ImageScrollingDemo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            PopulateVMs();
            ImageCache.Initialize();
            this.InitializeComponent();            
        }

        public void PopulateVMs()
        {
            BigList = new ObservableCollection<ImageGroupVM>();
            Random r = new Random(42);
            for (int i = 0; i < 100_000; i++)
            {
                var groupImages = new List<int>(10);
                for (int j = 0; j < 10; j++)
                {
                    groupImages.Add((short)r.Next(251));
                }
                BigList.Add(new ImageGroupVM() { ImageIndices = groupImages });
            }
        }

        public ObservableCollection<ImageGroupVM> BigList { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}
