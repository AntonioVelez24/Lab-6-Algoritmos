using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Properties
    [SerializeField] private float playerSpeed;    
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject laserPrefab;

    [SerializeField] private TextMeshProUGUI textMode;

    [SerializeField] private GameManager gameManager;

    private enum Mode
    {
        Neutral,
        Attack,
        Defense
    }
    private Mode currentMode = Mode.Neutral;
    #endregion

    #region StartMethods
    private void Start()
    {
        UpdateTextMode();
    }
    #endregion
    #region PlayerMovement
    private void Update()
    {
        LimitPositionX();
    }
    public void LimitPositionX()
    {
        Vector2 currentPosition = player.transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, -7.5f, 7.5f);

        player.transform.position = currentPosition;
    }
    public void MoveLeft()
    {
        Vector3 newPosition = player.transform.position + Vector3.left * 2f;
        player.transform.position = newPosition;
        gameManager.CompleteTask("MoveLeft");

    }
    public void MoveRight()
    {
        Vector3 newPosition = player.transform.position + Vector3.right * 2f;
        player.transform.position = newPosition;
        gameManager.CompleteTask("MoveRight");
    }
    #endregion
    #region PlayerShooting
    public void Shoot()
    {
        Instantiate(laserPrefab, player.transform.position, Quaternion.identity);
        gameManager.CompleteTask("Shoot");
    }
    #endregion
    #region PlayerMode
    public void ChangeMode()
    {
        switch (currentMode)
        {
            case Mode.Attack:
                currentMode = Mode.Defense;
                break;

            case Mode.Defense:
                currentMode = Mode.Neutral;
                break;

            case Mode.Neutral:
                currentMode = Mode.Attack;
                break;
        }

        UpdateTextMode();
        gameManager.CompleteTask("SwapModes");
    }
    private void UpdateTextMode()
    {
        switch (currentMode)
        {
            case Mode.Attack:
                textMode.text = "Modo: Ataque";
                textMode.color = Color.red;
                break;
            case Mode.Defense:
                textMode.text = "Modo: Defensa";
                textMode.color = Color.blue;
                break;
            case Mode.Neutral:
                textMode.text = "Modo: Neutral";
                textMode.color = Color.white;
                break;
        }
    }
    #endregion
}
