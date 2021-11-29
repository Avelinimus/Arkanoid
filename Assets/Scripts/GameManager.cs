using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text _livesText;
    [SerializeField]
    private GameObject _gameObject;
    [SerializeField]
    private GameObject _ballPrefab;
    [SerializeField]
    private GameObject _ball;
    [SerializeField]
    private GameObject _saveBottomWall;


    public static bool isSaveBottom = false;
    public static bool isScalePlatform = false;

    public static float timeSaveBottom = 5;
    public static float timeScaleBottom = 5;

    public static int lives = 3;

    private void FixedUpdate()
    {
        ControllProject();
    }


    private void ControllProject() 
    {
        
        if (Time.frameCount % 2 == 0) 
        {
            UIWriter();
            GameOver();
            SaveBottom();
            ScalePlatform();
        }
    }

    private void GameOver() 
    {
        if (lives > 0) 
        {
            Respawn();
        }
    }

    private void UIWriter() 
    {
        _livesText.text = "Lives: " + lives;
    }

    private void Respawn() 
    {
        if (!_ball) 
        {
            lives -= 1;
            _ball = Instantiate(_ballPrefab, Ball.position, new Quaternion(), _gameObject.transform);
            _ball.name = "Ball";
        }
    }

    private void SaveBottom() 
    {
        if (isSaveBottom && timeSaveBottom >= 0)
        {
            timeSaveBottom -= Time.deltaTime;
        }
        else 
        {
            isSaveBottom = false;
        }
        _saveBottomWall.SetActive(isSaveBottom);
    }

    private void ScalePlatform() 
    {
        if (isScalePlatform && timeScaleBottom >= 0)
        {
            timeScaleBottom -= Time.deltaTime;
            Player.scalePlayer = new Vector3(135f, 10f, 1f);
        }
        else 
        {
            isScalePlatform = false;
            Player.scalePlayer = new Vector3(100f, 10f, 1f);
        } 
    }
}
