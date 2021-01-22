using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabsList = new GameObject[] { };
    
    private void FixedUpdate()
    {
        CheckBlock();
    }

    void CheckBlock()
    {
        float leftX = Player.leftX;
        if (transform.childCount <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Instantiate(_prefabsList[Random.Range(0, _prefabsList.Length)], 
                        new Vector3(-5 + leftX + i * -leftX /2f, 50 + j * -5, 0) + transform.position, new Quaternion(), transform);
                    //Debug.Log(leftX);
                }
            }
        }
    }
}
