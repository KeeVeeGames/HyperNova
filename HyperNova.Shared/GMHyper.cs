using System;
using System.Diagnostics;
using System.IO;

namespace HyperNova.Shared
{
    public class GMHyper
    {
        private Process _process;

        public bool IsStarted { get; private set; }

        public void Start(string workingDirectory)
        {
            string executablePath = $"{workingDirectory}\\GMHyper.exe";

            if (File.Exists(executablePath))
            {
                _process = new Process();

                _process.StartInfo.FileName = executablePath;
                _process.StartInfo.WorkingDirectory = workingDirectory;

                _process.StartInfo.UseShellExecute = false;
                _process.StartInfo.RedirectStandardOutput = true;
                _process.EnableRaisingEvents = true;
                _process.StartInfo.CreateNoWindow = true;

                _process.OutputDataReceived += OutputHandlerInner;
                _process.Exited += ExitedHandlerInner;

                _process.Start();
                _process.BeginOutputReadLine();

                IsStarted = true;
            }
            else
            {
                throw new FileNotFoundException($"GMHyper.exe doesn't exist in {workingDirectory} location!");
            }
        }

        public void Close(bool kill = false)
        {
            _process.CancelOutputRead();

            if (kill)
            {
                _process.Kill();
            }

            _process.Close();
            _process.Refresh();

            IsStarted = false;
        }

        public event EventHandler ExitedHandler;

        private void ExitedHandlerInner(object sender, EventArgs e)
        {
            Close();
            ExitedHandler?.Invoke(sender, e);
        }

        public event DataReceivedEventHandler OutputHandler;

        private void OutputHandlerInner(object sender, DataReceivedEventArgs e)
        {
            OutputHandler?.Invoke(sender, e);
        }
    }
}
