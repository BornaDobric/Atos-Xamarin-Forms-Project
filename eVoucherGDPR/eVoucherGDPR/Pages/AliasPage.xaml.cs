using eVoucherGDPR.Model;
using eVoucherGDPR.ViewModel;
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
    public partial class AliasPage : ContentPage
    {
        public string broj = "0996492854";
        public string alias1;

        public AliasPage()
        {
            InitializeComponent();
        }

        void CheckAliasButtonClicked(object sender, EventArgs e)
        {
            alias1 = aliasInput.Text;
            StartConnectionAsync();
        }

        private async Task StartConnectionAsync()
        {
            String api = "https://evouchergdpr.azurewebsites.net/api/Values?broj=" + broj + "&alias1=" + alias1;
            
            HttpWebResponse response = null;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(api);
            request.Method = "GET";
            String str;

            try
            {
                using (response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    str = sr.ReadToEnd();
                    alias1 = str;
                    newAlias.Text = "Trenutni alias za korištenje: " + alias1;
                    MessagingCenter.Send<AliasPage, string>(this, "HelloMessage", alias1);
                }
            }
            catch
            {
                DisplayAlert("Greška!", "Došlo je do greške!", "Nastavi");
            }
        }
    }
}