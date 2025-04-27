using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PriorityQueue<Task> taskQueue = new PriorityQueue<Task>();

    [SerializeField] private TextMeshProUGUI taskText;
    void Start()
    {
        FillTasks();
    }
    void Update()
    {
        
    }

    [Button("Llenar Tareas")]
    public void FillTasks()
    {
        taskQueue.Enqueue(new Task(Task.taskType.Shoot), 3);
        taskQueue.Enqueue(new Task(Task.taskType.MoveLeft), 1);
        taskQueue.Enqueue(new Task(Task.taskType.MoveRight), 0);
        taskQueue.Enqueue(new Task(Task.taskType.BarrelRoll), 2);

        ShowCurrentTask();
    }
    [Button("Mostrar Tareas")]
    public void ShowTasks()
    {
        taskQueue.ReadQueue();
    }
    [Button("Completar Tarea")]
    public void CompleteTask()
    {
        taskQueue.Dequeue();
        ShowCurrentTask();
    }
    [Button("Mostrar Tareas en Consola")]
    private void ShowCurrentTask()
    {
        if (taskQueue.Count <= 0 || taskQueue.Head == null)
        {
            taskText.text = "Todas las tareas completadas.";
            return;
        }
        taskQueue.TryPeek(out var headNode, out int prio);

        var task = headNode.Value;
        taskText.text = "Tarea actual: " + task.GetDescription();         
    }
}
