using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private RectTransform _playerPosition;

    [SerializeField]
    private RectTransform _leftSolid;

    [SerializeField]
    private RectTransform _rightSolid;

    public static Vector3 position;
    public static float speed = 40;

    public static Vector3 scalePlayer;

    public static float leftX;
    public static float rightX;
    private void Start()
    {
        Init();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Controll();
    }

    private void Init() 
    {
        position = _playerPosition.position;
        position = new Vector3(0, 0, 0) + position;

        leftX = _leftSolid.position.x;
        rightX = _rightSolid.position.x;

        scalePlayer = transform.localScale;
    }

    private void CheckPositionPlayer() 
    {
        leftX = _leftSolid.position.x;
        rightX = _rightSolid.position.x;
        const float coef = 9;
        //Debug.Log(position.x);
        if (position.x < leftX + coef)
        {
            //Debug.Log("left zone");
            position.x = leftX + coef;
        } else if (position.x > rightX - coef) 
        {
            //Debug.Log("right zone");
            position.x = rightX - coef;
        }
    }

    private void InputKeys() 
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D)) 
        {
            //Debug.Log("D");
            position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        
    }

    private void Controll() 
    {
        InputKeys();
        CheckPositionPlayer();
        transform.localScale = scalePlayer;
        _playerPosition.position = position;
    }
}
