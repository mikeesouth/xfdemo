using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace xfdemo
{
    public class MainPageViewModel
    {
        public ICommand CustomButtonCommand { get; private set; }
        public ICommand NativeButtonCommand { get; private set; }
        public ICommand FloatingButtonCommand { get; private set; }

        public MainPageViewModel(Page page)
        {
            CustomButtonCommand = new Command(() => { page.DisplayAlert("CLICK!", "Custom renderer button", "OK"); } );
            NativeButtonCommand = new Command(() => { page.DisplayAlert("CLICK!", "Native renderer button", "OK"); } );
            FloatingButtonCommand = new Command(() => { page.DisplayAlert("CLICK!", "Floating action button", "OK"); } );
        }
    }
}
