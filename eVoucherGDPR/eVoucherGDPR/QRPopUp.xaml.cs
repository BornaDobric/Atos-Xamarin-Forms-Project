using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace eVoucherGDPR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRPopUp : PopupPage
    {
        string alias;
        StackLayout stackL;
        ZXingBarcodeImageView barcode;
        public QRPopUp()
        {
            InitializeComponent();
        }

        public QRPopUp(AliasObject aliasPerson)
        {
            InitializeComponent();
            BindingContext = aliasPerson;
        }

        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}