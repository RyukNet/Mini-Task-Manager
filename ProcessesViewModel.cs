using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Threading;

namespace MiniTaskManager
{
    class ProcessesViewModel
    {
        public ObservableCollection<Process> processes { get; } = new ObservableCollection<Process>();

        public ProcessesViewModel()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += UpdateProcesses;
            timer.Start();
        }

        private void UpdateProcesses(object sender, EventArgs e)
        {
            var liveIds = processes.Select(p => p.Id).ToList();
            foreach(var p in Process.GetProcesses())
            {
                if (!liveIds.Remove(p.Id))
                {
                    processes.Add(p);
                }
            }

            foreach (var id in liveIds)
            {
                processes.Remove(processes.First(p => p.Id == id));
            }
        }
    }
}
