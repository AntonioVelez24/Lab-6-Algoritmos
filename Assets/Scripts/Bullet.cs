using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Speed
    [SerializeField] private float bulletSpeed;
    #endregion

    #region Update
    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

        if(transform.position.y > 8)
            Destroy(gameObject);
    }
    #endregion
}
