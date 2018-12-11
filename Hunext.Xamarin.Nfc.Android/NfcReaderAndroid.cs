using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Nfc;
using Android.Nfc.Tech;
using Android.OS;

namespace Hunext.Xamarin.Nfc.Android
{

    public class NfcReaderAndroid : Java.Lang.Object, INfcReader, NfcAdapter.IReaderCallback
    {
        private readonly NfcAdapter _nfcAdapter;
        public event TagDetectedDelegate TagDetected;
        static Func<Activity> _activityResolver;
        public static Activity CurrentActivity => GetCurrentActivity();

        private static Activity GetCurrentActivity()
        {
            if (_activityResolver == null)
                throw new InvalidOperationException("Error finding resolver for the current activity.");

            return _activityResolver();
        }

        public static void SetActivityResolver(Func<Activity> activityResolver)
        {
            _activityResolver = activityResolver;
        }

        public static void OnNewIntent(Intent intent)
        {
            ((NfcReaderAndroid)NfcReader.Current).CheckNfcMessage(intent);
        }

        public NfcReaderAndroid()
        {
            _nfcAdapter = NfcAdapter.GetDefaultAdapter(CurrentActivity);
        }

        public async Task<bool> IsReaderAvailableAsync()
        {
            var context = Application.Context;
            if (context.CheckCallingOrSelfPermission(Manifest.Permission.Nfc) != Permission.Granted)
                return false;

            return _nfcAdapter != null;
        }

        public Task<bool> IsReaderEnabledAsync()
        {
            return Task.FromResult(_nfcAdapter?.IsEnabled ?? false);
        }

        public async Task StartReadingAsync()
        {
            if (!await IsReaderAvailableAsync()) throw new InvalidOperationException("NFC reader not available");

            if (!await IsReaderEnabledAsync()) throw new InvalidOperationException("NFC reader is not enabled");

            var act = CurrentActivity;
            var tagDetected = new IntentFilter(NfcAdapter.ActionNdefDiscovered);

            tagDetected.AddDataType("*/*");

            var filters = new[] { tagDetected };
            var intent = new Intent(act, act.GetType()).AddFlags(ActivityFlags.SingleTop);
            var pendingIntent = PendingIntent.GetActivity(act, 0, intent, 0);

            _nfcAdapter.EnableReaderMode(act, this, NfcReaderFlags.NfcA | NfcReaderFlags.NoPlatformSounds, null);

        }

        public async Task StopReadingAsync()
        {
            _nfcAdapter?.DisableReaderMode(CurrentActivity);
        }

        internal void CheckNfcMessage(Intent intent)
        {
            if (intent.Action != NfcAdapter.ActionTagDiscovered) return;
        }

        public void OnTagDiscovered(Tag tag)
        {
            try
            {
                var techs = tag.GetTechList();
                if (!techs.Contains(Java.Lang.Class.FromType(typeof(Ndef)).Name))
                    return;

                var ndef = Ndef.Get(tag);
                ndef.Connect();
                var ndefMessage = ndef.NdefMessage;
                var records = ndefMessage.GetRecords();
                ndef.Close();

                var nfcTag = new NfcTag(ndef, records);
                TagDetected?.Invoke(nfcTag);
            }
            catch
            {

            }
        }
    }
}