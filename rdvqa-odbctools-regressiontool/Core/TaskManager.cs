using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core
{
    class TaskManager
    {
        private List<Task> Tasks;

        public static TaskManager AppTaskManager = new TaskManager();
        private TaskManager()
        {
            Tasks = new List<Task>();
            Task task = new Task(TaskChecker, TaskCreationOptions.LongRunning);
            Tasks[0] = task;
            task.RunSynchronously();
            
        }
        public void RunNewTask(Action action)
        {
            //Task task = new Task(action, TaskCreationOptions.LongRunning);
            //Tasks.Add(task);
            //task.RunSynchronously(TaskScheduler.Default);            
        }
        private void TaskChecker()
        {
            
        }

    }
}
