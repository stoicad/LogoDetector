using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogoDetector.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogoDetector.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage(Stream stream)
        {
            InitializeComponent();
            ((PageResultsViewModel) BindingContext).SearchForLogo(stream);
        }

    }
}