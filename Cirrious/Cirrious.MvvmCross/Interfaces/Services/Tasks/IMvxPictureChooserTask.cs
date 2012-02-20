using System;
using System.IO;

namespace Cirrious.MvvmCross.Interfaces.Services.Tasks
{
    public interface IMvxPictureChooserTask
    {
        void ChoosePictureFromLibrary(int maxPixelDimension, int percentQuality, Action<Stream> pictureAvailable, Action assumeCancelled);
        void TakePicture(int maxPixelDimension, int percentQuality, Action<Stream> pictureAvailable, Action assumeCancelled);
    }
}