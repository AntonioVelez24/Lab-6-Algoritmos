using UnityEngine;
using static Task;

public class Task 
{
    #region Properties
    [SerializeField] private taskType type;
    public enum taskType
    {
        Shoot,
        MoveLeft,
        MoveRight,
        BarrelRoll,
        SwapModes,
    }
    #endregion

    #region Constructors
    public Task(taskType Type)
    {
        type = Type;
    }
    #endregion

    #region Getters
    public taskType Type => type;
    #endregion

    #region Methods
    public string GetDescription()
    {
        switch (type)
        {
            case taskType.Shoot:
                return "Dispara al objetivo.";
            case taskType.MoveLeft:
                return "Muévete a la izquierda.";
            case taskType.MoveRight:
                return "Muévete a la derecha.";
            case taskType.BarrelRoll:
                return "Haz un giro!!.";
            case taskType.SwapModes:
                return "Cambia de modo.";
            default:
                return "Tarea desconocida.";
        }
    }
    #endregion
}
