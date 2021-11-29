using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private Material[] _materialList = new Material[] { };
    [SerializeField]
    private GameObject[] _bonusList = new GameObject[] { };


    private int lives;

    private void Awake()
    {
        Init();
    }

    private void OnDestroy()
    {
        if (Random.Range(0, 2) == 1)
        {
            int isObj = Random.Range(0, _bonusList.Length);
            GameObject obj = Instantiate(_bonusList[isObj],
                transform.position, new Quaternion(), Bonus.BonuseGameObject.transform);
            if (isObj == 0)
            {
                obj.name = "Bonus_lives";
            }
            else if (isObj == 1)
            {
                obj.name = "Bonus_size";
            }
            else if (isObj == 2)
            {
                obj.name = "Bonus_wall";
            }
        }
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.name == "Ball")
        {
            lives -= 1;
            
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
            else 
            {
                //Debug.Log(_materialList[lives - 1]);
                gameObject.GetComponent<MeshRenderer>().material = _materialList[lives - 1];
            }
            
        }
    }

    private void Init()
    {
        
        lives = Random.Range(1, 4);
        gameObject.GetComponent<MeshRenderer>().material = _materialList[lives - 1];
    }
}
