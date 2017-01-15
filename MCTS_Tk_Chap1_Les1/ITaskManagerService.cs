using System.Collections.Generic;
using System.ServiceModel;
using MCTS_Tk_Chap1_Les1.DataContracts;

namespace MCTS_Tk_Chap1_Les1
{
    [ServiceContract(Name = "TaskManagerService", 
        Namespace = "http://schemas.fabricam.com/2008/04/tasks/")]
    public interface ITaskManagerService
    {
        [OperationContract]
        TaskAcknowlegement AddTask(Task taskParameters);

        [OperationContract]
        List<Task> GetTasksByAssignedName(string assignedTo);

        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        Task GetTask(int taskNumber);

        [OperationContract]
        string GetTaskDescription(int taskNumber);

        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        void MarkTaskCompleted(int taskNumber);

        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        void DeleteTask(int taskNumber);
    }
}
