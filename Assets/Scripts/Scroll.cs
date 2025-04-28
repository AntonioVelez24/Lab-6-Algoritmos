using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    #region Properties
    [SerializeField] private float speed;
    [SerializeField] private float height;

    private Vector3 initialPosition;
    #endregion

    #region Methods
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < initialPosition.y - height)
            transform.position = new Vector2(transform.position.x, initialPosition.y);
    }
    #endregion
}
