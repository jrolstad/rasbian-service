using System;
using System.Media;
using System.ServiceProcess;
using System.Timers;

namespace rasbian_service
{
    public partial class TimerService : ServiceBase
    {
        private readonly Timer _timer;

        public TimerService()
        {
            InitializeComponent();

            _timer = new Timer {Interval = TimeSpan.FromSeconds(10).TotalMilliseconds};
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var filePath = "my-file.txt";
            var message = string.Format("{0} - {1}",DateTime.Now,Environment.OSVersion);
            System.IO.File.AppendAllText(filePath,message);

            SystemSounds.Beep.Play();
        }

        protected override void OnStart(string[] args)
        {
            _timer.Start();
        }

        protected override void OnStop()
        {
            _timer.Stop();
        }
    }
}
