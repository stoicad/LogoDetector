using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Xamarin.Forms;

namespace LogoDetector.ViewModels
{
    public class PageResultsViewModel : ViewModelBase
    {
        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get => imageSource;
            set => SetProperty(ref imageSource, value);
        }

        public async void SearchForLogo(Stream stream)
        {
            ImageSource = ImageSource.FromStream(() => stream);

        }
    }
}
