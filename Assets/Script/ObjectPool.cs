using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectPool : MonoBehaviour
{
    public Transform ball;
    public float ballspeed;
    public float move;
    public float height;
    public List<Transform> tiles;
    public int point1 = 0;
    public int point2 = 1;
    public float offset;
    public float ballheightoffset;    
    public Vector3 ballPosition;
    [SerializeField] private ScoreManager scoreManager;
    public int score;
    

    public float xPos;
    public Vector3 ypos;
    private Touch touch;
    private float movementSpeed = 0.01f;
    public float minValue;
    public float maxValue;
    public bool gameOver;
    public Canvas GameOver;
    public AudioSource audioball;

    private void Start()
    {
        Time.timeScale = 0;
        ballPosition = transform.position;
    }
    void Update()
    {
        if (gameOver)
        {
            move = 0;
            transform.position = ballPosition;
            return;
        }

        if (Input.touchCount > 0)
        {
            Time.timeScale = 1;
        }
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                xPos = transform.position.x + touch.deltaPosition.x * movementSpeed;
                xPos = Mathf.Clamp(xPos, minValue, maxValue);

            }

        }        
        move += Time.deltaTime * ballspeed;
        ball.position = Beizerpoint(tiles[point1].position, tiles[point2].position, move);       


        if (move >= 1f)
        {

            float chd = tiles[point2].transform.localScale.x / 2;
            float distance = Mathf.Abs(ball.transform.position.x - tiles[point2].transform.position.x);

            if (chd < distance)
            {
                Debug.LogError("GameOver!");
                GameOver.enabled = true;
                scoreManager.CheckHighScore();
                gameOver = true;                
            }
            else
            {
                int target = 0;
                move = 0;
                if (point1 == 0)
                    target = tiles.Count - 1;
                else
                    target = point1 - 1;

                Vector3 off = tiles[target].transform.position;
                off.z = off.z + offset + Random.Range(-1f, 1f);
                off.x = Random.Range(-1f, 1f);

                tiles[point1].position = off;

                point1 = point2;
                point2++;
                if (point2 > tiles.Count - 1)
                    point2 = 0;

                audioball.Play();
                scoreManager.ScoreIncrease();
            }


        }

    }
    Vector3 Beizerpoint(Vector3 p1, Vector3 p2, float speed)
    {
        p1.y = p1.y + ballheightoffset;
        p2.y += ballheightoffset;
        Vector3 p3 = (p2 + p1) / 2;///center point
        p3.y = p3.y + height;///p3 height
        Vector3 target13 = Vector3.Lerp(p1, p3, speed);
        Vector3 target32 = Vector3.Lerp(p3, p2, speed);
        Vector3 AB_BC = Vector3.Lerp(target13, target32, speed);


        AB_BC.x = xPos;
        return AB_BC;
    }
}