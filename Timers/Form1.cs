using System;
using System.Timers;
using System.Windows.Forms;

namespace Timers
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(dropList.Text))
            {
                if (checkBox1.CheckState == CheckState.Checked)
                    this.ShowInTaskbar = false; // hide the application icon from the taskbar

                this.WindowState = FormWindowState.Minimized; // Minimize the application after confirming the command

                //start the Timer
                timer.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //create an interval of 1 sec to call the function every 1 second
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed; //The name of the function that we are going to create
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime desiredTime = dateTimePicker1.Value;

            Invoke(new Action(() =>
            {
                //Compare the current time with the desired Time
                if (currentTime.Hour == desiredTime.Hour && currentTime.Minute == desiredTime.Minute &&
                    currentTime.Second == desiredTime.Second)
                {
                    timer.Stop();
                    Run(); // the function that does all the operations
                    Application.Exit();
                }
            }));

        }


        public void Run()
        {
            switch (dropList.Text)
            {
                case "Shut Down":
                    System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                    break;

                case "Restart":
                    System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                    break;

                case "Sleep":
                    Application.SetSuspendState(PowerState.Suspend, false, true);
                    break;

                case "Open Whatsapp":
                    System.Diagnostics.Process.Start("https://web.whatsapp.com/");
                    break;

                // Of course you can add your own operation or task here or you can add your favourite website to open it!


            }

        }


    }
}
