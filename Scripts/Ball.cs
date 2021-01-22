using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private RectTransform _ballPosition;
    [SerializeField]
    private Rigidbody _ballRigidbody;

   

    public static Vector3 position;
    public static Rigidbody ballRigidbody;
    public static Vector3 ballVelocity;
    public static float speed = 70;

    
    private void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {
            ballVelocity = ballRigidbody.velocity;
    }

    void OnCollisionEnter(Collision collision) 
    {
        
        if (collision.gameObject.tag == "Solid") 
        {
            if (collision.gameObject.name == "LeftWall" || collision.gameObject.name == "RightWall")
            {
                ballRigidbody.velocity = new Vector3(-ballVelocity.x, ballVelocity.y, 0);
            }
            if (collision.gameObject.name == "TopWall") 
            {
                ballRigidbody.velocity = new Vector3(ballVelocity.x, -ballVelocity.y, 0);
            }
        }

        if (collision.gameObject.name == "Bonus_lives") 
        {
            GameManager.lives += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Bonus_size")
        { 
            GameManager.isScalePlatform = true;
            GameManager.timeScaleBottom = 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Bonus_wall")
        {
            GameManager.isSaveBottom = true;
            GameManager.timeSaveBottom = 5;
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.tag == "Blocks") 
        {
            ballRigidbody.velocity = new Vector3(ballVelocity.x, -ballVelocity.y, 0);
        }
        if (collision.gameObject.name == "Player")
        {
            ballRigidbody.velocity = new Vector3(ballVelocity.x + Random.Range(-5, 5), -ballVelocity.y, 0);

        }
        if (collision.gameObject.name == "BottomWall")
        {
            Destroy(gameObject);
        }
        ballVelocity = ballRigidbody.velocity;
    }

    private void Init()
    {

        position = _ballPosition.position;
        position = new Vector3(0, 0, 0) + position;

        ballRigidbody = _ballRigidbody;
        ballRigidbody.AddForceAtPosition(new Vector3(Random.Range(-20, 20), speed, 0), position, ForceMode.Impulse);
        
    }
}
