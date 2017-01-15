using System;
using System.Collections.Generic;
using System.ServiceModel;
using MCTS_Tk_Chap1_Les1.DataContracts;
using MCTS_Tk_Chap1_Les1.Models;

namespace MCTS_Tk_Chap1_Les1
{
    public class TaskManagerService : ITaskManagerService
    {
        private static int _sNextTaskNumber = 1;
        private static readonly Dictionary<int, Task> _sActiveTasks = new Dictionary<int, Task>();

        public TaskAcknowlegement AddTask(Task task)
        {
            var taskNum = _sNextTaskNumber++;
            var taskAckn = new TaskAcknowlegement {TaskNumber = taskNum};
            task.TaskNumber = taskNum;

            task.TaskState = task.DueDate > DateTime.Now ? TaskStates.Active : TaskStates.Overdue;

            taskAckn.TaskState = task.TaskState;
            taskAckn.Comment = taskAckn.TaskState == TaskStates.Overdue ? 
                "Warning: task is already overdue" : null;

            Console.WriteLine($"Adding task: {task.TaskNumber}");
            _sActiveTasks.Add(taskNum, task);
            return taskAckn;
        }

        public List<Task> GetTasksByAssignedName(string assignedTo)
        {
            throw new NotImplementedException();
        }

        public string GetTaskDescription(int taskNumber)
        {
            if (!_sActiveTasks.ContainsKey(taskNumber))
            {
                var msg = $"No task with number {taskNumber}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
            var descr = _sActiveTasks[taskNumber].Description;
            Console.WriteLine($"Description for task num {taskNumber}: {descr}");
            return descr;
        }

        public bool IsTaskCompeleted(int taskNumber)
        {
            throw new NotImplementedException();
        }

        public void MarkTaskCompleted(int taskNumber)
        {
            if (!_sActiveTasks.ContainsKey(taskNumber))
            {
                var msg = $"No task with number: {taskNumber}";
                var fi = new FaultInfo {Reason = msg};
                throw new FaultException<FaultInfo>(fi);
            }
            var task = _sActiveTasks[taskNumber];
            task.TaskState = DateTime.Now > task.DueDate ? 
                TaskStates.CompletePastDueDate : 
                TaskStates.CompleteByDueDate;

            Console.WriteLine($"Task number {taskNumber} marked as completed");
        }

        public void DeleteTask(int taskNumber)
        {
            throw new NotImplementedException();
        }

        public Task GetTask(int taskNumber)
        {
            throw new NotImplementedException();
        }
    }
}
