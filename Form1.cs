using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Media;

namespace timer
{
   

    public partial class AutoTime : Form
    {
       TimeSpan lastDuration = new TimeSpan (0,0,0);
 
            public AutoTime()
        {
            InitializeComponent();
            
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }


        void Form1_DragEnter(object sender,DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
        }
        public static string ExtractFilename(string filepath)
        {
            // If path ends with a "\", it's a path only so return String.Empty.
            if (filepath.Trim().EndsWith(@"\"))
                return String.Empty;

            // Determine where last backslash is.
            int position = filepath.LastIndexOf('\\');
            // If there is no backslash, assume that this is a filename.
            if (position == -1)
            {
               
                    return filepath.Substring(0,filepath.Length-3);

            }
            else
            {
                // Return filename without file path.
               filepath =
                    filepath.Substring(position + 1);
                filepath= filepath.Substring(0,filepath.Length-3);
                return filepath;

            }
        }
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            TimeSpan time = new TimeSpan();
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string mediaFile in files)
            {
                var duration = (GetMediaDuration(mediaFile, time));
                duration = new TimeSpan(duration.Hours, duration.Minutes, duration.Seconds);
               // duration = duration.Substring(3, 5);
                 Log.AppendText(ExtractFilename(mediaFile) +" - " +lastDuration + Environment.NewLine);
                lastDuration = lastDuration.Add(duration);
            }
           

        }
        static TimeSpan GetMediaDuration(string mediaFile)
        {
            return GetMediaDuration(mediaFile, TimeSpan.Zero);
        }

        static TimeSpan GetMediaDuration(string mediaFile, TimeSpan maxTimeToWait)
        {
            var mediaData = new MediaData() { MediaUri = new Uri(mediaFile) };

            var thread = new Thread(GetMediaDurationThreadStart);
            DateTime deadline = DateTime.Now.Add(maxTimeToWait);
            thread.Start(mediaData);

            while (!mediaData.Done && ((TimeSpan.Zero == maxTimeToWait) || (DateTime.Now < deadline)))
                Thread.Sleep(100);

            Dispatcher.FromThread(thread).InvokeShutdown();

            if (!mediaData.Done)
                throw new Exception(string.Format("GetMediaDuration timed out after {0}", maxTimeToWait));
            if (mediaData.Failure)
                throw new Exception(string.Format("MediaFailed {0}", mediaFile));

            return mediaData.Duration;
        }

        static void GetMediaDurationThreadStart(object context)
        {
            var mediaData = (MediaData)context;
            var mediaPlayer = new MediaPlayer();

            mediaPlayer.MediaOpened +=
                delegate
                {
                    if (mediaPlayer.NaturalDuration.HasTimeSpan)
                        mediaData.Duration = mediaPlayer.NaturalDuration.TimeSpan;
                    mediaData.Success = true;
                    mediaPlayer.Close();
                };

            mediaPlayer.MediaFailed +=
                delegate
                {
                    mediaData.Failure = true;
                    mediaPlayer.Close();
                };

            mediaPlayer.Open(mediaData.MediaUri);

            Dispatcher.Run();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {

        }

        private void clearItem_Click(object sender, EventArgs e)
        {
            Log.Clear();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class MediaData
    {
        public Uri MediaUri;
        public TimeSpan Duration = TimeSpan.Zero;
        public bool Success;
        public bool Failure;
        public bool Done { get { return (Success || Failure); } }
    }
}

