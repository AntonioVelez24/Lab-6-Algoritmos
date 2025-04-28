using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Properties
    private PriorityQueue<Task> taskQueue = new PriorityQueue<Task>();

    [SerializeField] private TextMeshProUGUI taskText;
    #endregion

    #region StartMethods
    void Start()
    {
        FillTasks();
    }
    public void FillTasks()
    {
        taskQueue.Enqueue(new Task(Task.taskType.Shoot), 1);
        taskQueue.Enqueue(new Task(Task.taskType.MoveLeft), 2);
        taskQueue.Enqueue(new Task(Task.taskType.MoveRight), 3);
        taskQueue.Enqueue(new Task(Task.taskType.SwapModes), 0);

        ShowCurrentTask();
    }
    #endregion

    #region Methods
    private void ShowCurrentTask()
    {
        if (taskQueue.Count <= 0 || taskQueue.Head == null)
        {
            taskText.text = "Felicidades!! Tutorial completado.";
            return;
        }
        taskQueue.TryPeek(out var headNode, out int prio);

        var task = headNode.Value;
        taskText.text = "Tarea actual: " + task.GetDescription();         
    }
    public void CompleteTask(string task)
    {
        if (taskQueue.Count <= 0)  
        {
            taskText.text = "No hay mas tareas para completar.";
            return; 
        }

        if (task == taskQueue.Head.Value.Type.ToString())
        {
            taskQueue.Dequeue();
            ShowCurrentTask();
        }
        else
            return;
    }
    #endregion
}
