using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogoDetector.Utils;
using Xamarin.Forms;

namespace LogoDetector
{
    public partial class MainPage : OrientationContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            OnOrientationChanged += DeviceRotated;
        }

        private void DeviceRotated(object s, PageOrientationEventArgs e)
        {

            switch (e.Orientation)
            {
                case PageOrientation.Horizontal:
                {
                    MainStackLayout.Orientation = StackOrientation.Horizontal;
                    LandingImageFrame.WidthRequest = LandingImage.Height - 40;
                    LandingImage.Rotation = 90;
                    LandingImageFrame.Padding = new Thickness(20);
                        break;
                    }

                case PageOrientation.Vertical:
                    {
                        MainStackLayout.Orientation = StackOrientation.Vertical;
                        LandingImageFrame.WidthRequest = LandingImage.Width;
                        LandingImage.Rotation = 0;
                        LandingImageFrame.Padding = new Thickness(10);
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(1000);
            radialMenu.IsOpen = true;
        }
    }
}
