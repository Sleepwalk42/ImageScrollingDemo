using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Streams;

namespace ImageScrollingDemo
{
    static class ImageCache
    {
        //images taken from https://github.com/NVlabs/ffhq-dataset

        static private List<ImageBrush> _imageBrushes;

        public static void Initialize()
        {
            _imageBrushes = new List<ImageBrush>();
            for (int i = 0; i < 251; i++)
            {
                var imageUri = new Uri($"ms-appx:///images/50{i:D3}.png");
                var imageBmp = LoadBitmap(imageUri);

                _imageBrushes.Add(new ImageBrush() { ImageSource = imageBmp });
            }
        }

        public static ImageBrush GetBrush(int index) => _imageBrushes[index];        

        private static BitmapImage LoadBitmap(Uri uri)
        {
            var storageFile = StorageFile.GetFileFromApplicationUriAsync(uri).AsTask().Result;
            var bitmap = new BitmapImage();

            using (IRandomAccessStream fileStream = storageFile.OpenAsync(FileAccessMode.Read).AsTask().Result)
            {
                bitmap.SetSource(fileStream);
            }

            return bitmap;
        }
    }
}
