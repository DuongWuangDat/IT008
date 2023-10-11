using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CancellationTokenSource cancelShutdownToken;
        private void btnShutdown_Click(object sender, EventArgs e)
        {
            ScheduleAction(Shutdown);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ScheduleAction(Restart);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ScheduleAction(Logout);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cancelShutdownToken != null)
            {
                cancelShutdownToken.Cancel();
            }
        }

        private void ScheduleAction(Action action)
        {
            int delayInSeconds;
            if (txtDelay.Text.Length > 0)
            { delayInSeconds = int.Parse(txtDelay.Text); }
            else { delayInSeconds = 0; }
            if (delayInSeconds > 0)
            {
                cancelShutdownToken = new CancellationTokenSource();
                ThreadPool.QueueUserWorkItem(state =>
                {
                    if (cancelShutdownToken.Token.WaitHandle.WaitOne(delayInSeconds * 1000))
                    {
                        return;
                    }
                    action();

                });
            }
        }

        private void Shutdown()
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void Restart()
        {
            Process.Start("shutdown", "/r /t 0");
        }

        private void Logout()
        {
            Process.Start("shutdown", "/l");
        }
    }
}
