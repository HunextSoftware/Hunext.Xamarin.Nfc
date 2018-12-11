using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFoundation;
using CoreNFC;
using Foundation;

namespace Hunext.Xamarin.Nfc.iOS
{

    public class NfcReaderiOS : NSObject, INFCNdefReaderSessionDelegate, INfcReader
    {
        private NFCNdefReaderSession _session;
        private TaskCompletionSource<NfcTag> _tcs;

        public event TagDetectedDelegate TagDetected;

        public Task<NfcTag> ScanAsync()
        {
            if (!NFCNdefReaderSession.ReadingAvailable)
            {
                throw new InvalidOperationException("NFC Reader is not available");
            }

            _tcs = new TaskCompletionSource<NfcTag>();
            _session = new NFCNdefReaderSession(this, DispatchQueue.CurrentQueue, true);
            _session.BeginSession();
            
            return _tcs.Task;
        }

        public Task StopScanAsync(){
            _session.InvalidateSession();
            return _tcs.Task;
        }

        public void DidInvalidate(NFCNdefReaderSession session, NSError error)
        {
            _tcs.TrySetException(new Exception(error?.LocalizedFailureReason));
        }

        public void DidDetect(NFCNdefReaderSession session, NFCNdefMessage[] messages)
        {

            var message = messages.FirstOrDefault();
            var tag = new NfcTag(message, message.Records);
            _tcs.SetResult(tag);
        }

        public async Task<bool> IsReaderAvailableAsync()
        {
            return NFCNdefReaderSession.ReadingAvailable;
        }

        public Task<bool> IsReaderEnabledAsync()
        {
            return Task.FromResult(true);
        }

        public async Task StartReadingAsync()
        {
            var message = await ScanAsync();

            TagDetected?.Invoke(message);
        }

        public async Task StopReadingAsync()
        {
            _session.InvalidateSession();
        }
    }



   
}