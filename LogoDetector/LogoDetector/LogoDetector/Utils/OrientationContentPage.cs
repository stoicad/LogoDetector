using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LogoDetector.Utils
{
    public class OrientationContentPage : ContentPage
    {
        private double width;
        private double height;

        public event EventHandler<PageOrientationEventArgs> OnOrientationChanged = (e, a) => { };

        public OrientationContentPage()
        {
            Init();
        }

        private void Init()
        {
            width = Width;
            height = Height;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            var oldWidth = this.width;
            const double sizeNotAllocated = -1;

            base.OnSizeAllocated(width, height);
            if (Equals(this.width, width) && Equals(this.height, height)) return;

            this.width = width;
            this.height = height;

            if (Equals(oldWidth, sizeNotAllocated)) return;

            // Has the device been rotated ?
            if (!Equals(width, oldWidth))
                OnOrientationChanged.Invoke(this, new PageOrientationEventArgs((width < height) ? PageOrientation.Vertical : PageOrientation.Horizontal));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }

    public class PageOrientationEventArgs : EventArgs
    {
        public PageOrientationEventArgs(PageOrientation orientation)
        {
            Orientation = orientation;
        }

        public PageOrientation Orientation { get; }
    }

    public enum PageOrientation
    {
        Horizontal = 0,
        Vertical = 1,
    }
}
