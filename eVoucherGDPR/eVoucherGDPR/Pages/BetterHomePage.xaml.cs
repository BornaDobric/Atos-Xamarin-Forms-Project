using eVoucherGDPR.Model;
using eVoucherGDPR.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVoucherGDPR.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BetterHomePage : ContentPage
    {
        AliasObject aliasPerson = new AliasObject();
        public string broj = "0996492854";
        public string alias1 = "";

        public BetterHomePage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<AliasPage, string>(this, "HelloMessage", (sender, a) => { alias1 = a; });
        }

        void OnSelectValue(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressedButton = button.Text;
            this.valueLabel.Text = "Odabrali ste bon od: " + pressedButton;
            if (!string.IsNullOrEmpty(pressedButton))
            {
                pressedButton = pressedButton.Remove(pressedButton.Length - 5);
                var aliasWithoutQuote = alias1.Trim('"');
                aliasPerson.AliasWithValue = pressedButton + "." + aliasWithoutQuote;
                trenAlias.Text = aliasPerson.AliasWithValue;
            }
        }

        public string RandomBrojMobitela()
        {
            String str = "";
            Random _random = new Random();

            for (int i = 0; i < 9; i++)
            {
                int num = _random.Next(0, 9);
                str = str + num;
            }
            return str;
        }

        async void OnGenerateQRCode(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new QRPopUp(aliasPerson));
        }
    }
}