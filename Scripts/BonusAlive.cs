using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAlive : MonoBehaviour
{
    private float aliveTime = 5f;
    // Update is called once per frame
    private void FixedUpdate()
    {
        aliveTime -= Time.deltaTime;
        if (aliveTime < 0) 
        {
            Destroy(gameObject);
        }
    }
}
