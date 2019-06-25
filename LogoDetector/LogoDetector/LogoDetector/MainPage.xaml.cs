using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogoDetector.Utils;
using LogoDetector.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.SfRadialMenu.XForms;
using Xamarin.Forms;
using ItemTappedEventArgs = Syncfusion.SfRadialMenu.XForms.ItemTappedEventArgs;

namespace LogoDetector
{
    public partial class MainPage : OrientationContentPage
    {
        private const string CameraItem = "Camera";
        private const string GalleryItem = "Gallery";
        private const string InfoItem = "Info";
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

        private async void SfRadialMenuItem_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            string name = ((SfRadialMenuItem)sender).StyleId;
            if (name == GalleryItem)
            {
                var picture = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions());
                var nextPage = new ResultsPage(picture.GetStream());
                await Navigation.PushAsync(nextPage);
            }
            if (name == CameraItem)
            {
                var picture = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions { DefaultCamera = CameraDevice.Front });
                var nextPage = new ResultsPage(picture.GetStream());
                await Navigation.PushAsync(nextPage);
            }

            if (name == InfoItem)
            {
                //var nextPage = new InfoPage();
                //await this.Navigation.PushAsync(nextPage);
            }
        }
    }

}
