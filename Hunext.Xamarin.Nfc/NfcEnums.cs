using System;
namespace Hunext.Xamarin.Nfc
{
    public enum TagRecType
    {
        Unknown     = -1,
        Empty       = 0,
        AbsoluteUri = 1,
        Media       = 2,
        External    = 3,
        WellKnown   = 4,
        Unchanged   = 5,

    }
}
