using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hunext.Xamarin.Nfc.Example
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NfcReader.Current.TagDetected += Current_TagDetected;;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!await NfcReader.Current.IsReaderAvailableAsync())
            {
                StatusNfc.Text = "NFC Reading not supported";
                return;
            }

            if (!await NfcReader.Current.IsReaderEnabledAsync())
            {
                StatusNfc.Text = "NFC Reader not enabled. Please turn it on in the settings.";
                return;
            }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await NfcReader.Current.StartReadingAsync();
        }

        async void Current_TagDetected(INfcTag tag)
        {
            StatusNfc.Text = System.Text.Encoding.UTF8.GetString(tag.Records[0].Payload);
            await NfcReader.Current.StopReadingAsync();
        }

    }
}
