using System;
using System.Threading.Tasks;

namespace Hunext.Xamarin.Nfc
{
    public interface INfcReader
    {
        event TagDetectedDelegate TagDetected;

        Task<bool> IsReaderAvailableAsync();
        Task<bool> IsReaderEnabledAsync();
        Task StartReadingAsync();
        Task StopReadingAsync();

    }
}
