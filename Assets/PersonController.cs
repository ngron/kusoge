using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PersonController : MonoBehaviour {

    Animator animator;

    Rigidbody2D rigid2D;

    GameObject gameOverText;

    private double movableRange = 6;

    private float jump = 13;


    public GameObject  scoreText;

    float maxY = 0f;


    private Transform personTrans;

    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>();

        this.rigid2D = GetComponent<Rigidbody2D>();

        gameOverText = GameObject.Find("GameOver");

        scoreText = GameObject.Find("ScoreText");

        scoreText.GetComponent<Text>().text = "Score:0";


    }

    // Update is called once per frame
    void Update()
    {

        if(this.transform.position.y >= maxY)
        {
            maxY = this.transform.position.y;

            scoreText.GetComponent<Text>().text = "Score:" + maxY;
        }


        //ボタンを押したときの処理
        if (Input.GetMouseButtonDown(0))
        {
            this.rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);

        }
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x <movableRange)
        {
            this.rigid2D.velocity = new Vector2(4, rigid2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x >-movableRange+0.5)
        {
            this.rigid2D.velocity = new Vector2(-4, rigid2D.velocity.y);
        }

       

    }


    //ステージに乗ったときに子要素になる
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "MoveStageTag")
        {
            transform.SetParent(other.transform);
        }

        if (other.gameObject.tag == "EnemyTag")
        {
            gameOverText.GetComponent<Text>().text = "GameOver";

            rigid2D.freezeRotation = false;
        }
    }
    //ステージから出た時に親要素になる
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MoveStageTag")
        {
            transform.SetParent(null);
        }
    }

}

