using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hunext.Xamarin.Nfc
{
    public class NfcReadeFake: INfcReader
    {
        private int _timeout;
        private string _tagdata;

        public NfcReadeFake(int timeout)
        {
            _timeout = timeout;
        }

        public NfcReadeFake(int timeout, string tagdata)
        {
            _timeout = timeout;
            _tagdata = tagdata;
        }

        public event TagDetectedDelegate TagDetected;

        public Task<bool> IsReaderAvailableAsync()
        {
            return Task.FromResult<bool>(true);
        }

        public Task<bool> IsReaderEnabledAsync()
        {
            return Task.FromResult<bool>(true);
        }

        public Task StartReadingAsync()
        {
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(_timeout);

                if (_tagdata == null) TagDetected?.Invoke(new NfcTagFake());
                else TagDetected?.Invoke(new NfcTagFake(_tagdata));

            });


            return Task.CompletedTask;
        }

        public Task StopReadingAsync()
        {
            return Task.CompletedTask;
        }
    }


}
