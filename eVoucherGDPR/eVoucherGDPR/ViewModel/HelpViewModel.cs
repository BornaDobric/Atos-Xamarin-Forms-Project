using eVoucherGDPR.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eVoucherGDPR.ViewModel
{
    public class HelpViewModel
    {
        public ObservableCollection<HelpModel> HelpList { get; set; }

        public HelpViewModel()
        {
            HelpList = new ObservableCollection<HelpModel>();
            HelpList.Add(new HelpModel { ShortDescription = "1. Odaberite alias.", LongDescription = "Pod Account upišite željeni alias. Ukoliko je slobodan dobit ćete potvrdnu poruku, inače se generira slobodni alias sa 3 random broja.", Image = "accimage.png" });
            HelpList.Add(new HelpModel { ShortDescription = "2. Izaberite ponuđenu cijenu bona.", LongDescription = "Pod Home su ponuđene opcije od 10, 25, 50 i 100 kuna. Odaberite cijenu.", Image = "moneyimage.png" });
            HelpList.Add(new HelpModel { ShortDescription = "3. Pritisnite QR kod kućicu.", LongDescription = "Na temelju vašeg aliasa i izabrane cijene bona generirat će se QR kod koji će prodavač skenirati sa svojom aplikacijom.", Image = "qrcode.png" });
            HelpList.Add(new HelpModel { ShortDescription = "4. Primanje poruke o nadoplati računa.", LongDescription = "Ukoliko je transakcija uspješno obavljena primit ćete potvrdnu poruku, inače će biti generirana poruka o grešci.", Image = "checkimage.png" });
        }
    }
}
