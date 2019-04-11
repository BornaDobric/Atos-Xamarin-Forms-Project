using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace eVoucherGDPR.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        AliasObject aliasPerson = new AliasObject();
        string aliasName;
        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(string str)
        {
            InitializeComponent();
            aliasName = str;
        }

        void OnSelectValue(object sender, EventArgs e)
        {
            string fullAlias;
            Button button = (Button)sender;
            string pressedButton = button.Text;
            this.valueLabel.Text = pressedButton + "kn";
            Label qrCode = kodZaQR;
            string moneyValue = valueLabel.Text;
            if (!string.IsNullOrEmpty(moneyValue))
            {
                moneyValue=moneyValue.Remove(moneyValue.Length - 2);
                qrCode.Text = "Kod: " + moneyValue + aliasName;
                qrCode.IsVisible = true;
            }
            fullAlias = moneyValue + aliasName;
            aliasPerson.AliasWithValue=fullAlias;
        }
        async void OnGenerateQRCode(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new QRPopUp(aliasPerson));
        }
    }
}