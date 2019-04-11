using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVoucherGDPR.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AliasPage : ContentPage
    {
        AliasObject aliasObj = new AliasObject();
        public AliasPage()
        {
            InitializeComponent();
        }

        async public void OnClickSend(object sender,EventArgs e)
        {
            string getEntryText = wantedAlias.Text;
            if (!string.IsNullOrEmpty(getEntryText))
            {
                aliasObj.AliasInput = getEntryText;
            }
            this.actualAlias.Text = aliasObj.AliasInput;
            await Navigation.PushModalAsync(new HomePage(aliasObj.AliasInput));
        }
    }
}