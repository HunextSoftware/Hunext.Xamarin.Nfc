using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hunext.Xamarin.Nfc
{
    public class NfcReadeFake: INfcReader
    {
        private int _delay;
        private NfcTagFake _tag;

        public NfcReadeFake(int timeout)
        {
            _delay = timeout;
        }

        public NfcReadeFake(int delay, NfcTagFake tag)
        {
            _delay = delay;
            _tag = tag;
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
                System.Threading.Thread.Sleep(_delay);

                if (_tag == null) TagDetected?.Invoke(NfcTagFake.RandomTextRecord());
                else TagDetected?.Invoke(_tag);

            });


            return Task.CompletedTask;
        }

        public Task StopReadingAsync()
        {
            return Task.CompletedTask;
        }
    }


}
