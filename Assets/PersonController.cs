using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersonController : MonoBehaviour {

    Rigidbody2D rigid2D;

    GameObject gameOverText;

    //可動範囲
    private double movableRange = 7;

    //ジャンプのスピード
    private float jump = 13;

    //スコアを取得
    GameObject  scoreText;

    //スコアの点数
    private float maxY = 0f;

    bool update = true;

    private bool jp = false;

    private Transform personTrans;


    // Use this for initialization
    void Start () {

        this.rigid2D = GetComponent<Rigidbody2D>();

        gameOverText = GameObject.Find("GameOver");

        scoreText = GameObject.Find("ScoreText");

        scoreText.GetComponent<Text>().text = "Score:0";


    }

    // Update is called once per frame
    void Update()
    {
        //y座標にいくほどスコアが加点されてく
        if (this.transform.position.y >= maxY && update)
        {
            maxY = this.transform.position.y;

            scoreText.GetComponent<Text>().text = "Score:" + maxY;
        }

        //画面外に出た時のx座標を決める
        if (this.transform.position.x < -movableRange)
        {
            this.transform.position = new Vector3(7, this.transform.position.y, 0);
        }
        if (this.transform.position.x > movableRange)
        {
            this.transform.position = new Vector3(-7, this.transform.position.y, 0);
        }


        //ボタンを押したときの処理
        if (Input.GetMouseButtonDown(0) && jp)
        {
            this.rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rigid2D.velocity = new Vector2(4, rigid2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rigid2D.velocity = new Vector2(-4, rigid2D.velocity.y);
        }

        //敵に当たって
        if (this.rigid2D.freezeRotation == false)
        {
            //クリックされたらシーンをロードする（追加）
            if (Input.GetMouseButtonDown(0))
            {
                //GameSceneを読み込む（追加）
                SceneManager.LoadScene("GameScene");
            }
        }

        
        


    }
    //ステージに触れた時の処理
    void OnCollisionEnter2D(Collision2D other)
    {

        //ステージに乗ったときにステージの子要素になる
        if (other.gameObject.tag == "MoveStageTag")
        {
            transform.SetParent(other.transform);

            //ジャンプを解放する
            jp = true;
        }

        if (other.gameObject.tag == "BottomTag")
        {
            jp = true;
        }

        //敵に当たったときの処理
        if (other.gameObject.tag == "EnemyTag")
        {
            update = false;
            gameOverText.GetComponent<Text>().text = "GameOver";

            this.rigid2D.freezeRotation = false;



        }
    }
    //ステージから出た時に親要素に戻る
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MoveStageTag")
        {
            transform.SetParent(null);

            jp = false;
        }
        if (other.gameObject.tag == "BottomTag")
        {
            jp = false;
        }
    }


}

