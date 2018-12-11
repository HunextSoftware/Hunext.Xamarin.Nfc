using System;
namespace Hunext.Xamarin.Nfc
{
    public interface INfcTag
    {
        NfcRecord[] Records { get; }
    }
}
