using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubu : MonoBehaviour {

    private Vector3 initialPosition;

    public bool m_moveLeftFirst = false;

    public float speed = 5;

    private float random = 50;

    bool setOff;

    BoxCollider2D colliderOfGround;

    // Use this for initialization
    void Start () {

        colliderOfGround = GetComponent<BoxCollider2D>();


        //最初のポジションを取得
        initialPosition = transform.position;

        //左右ランダムに動かす
        if (Random.Range(0, 100) > random)
        {
            m_moveLeftFirst = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //Leftfirstがtrueなら最初に左に動く、falseなら最初に右に動く
        if (m_moveLeftFirst)
        {

            transform.position = new Vector3((-1) * Mathf.Sin(Time.time) * speed + initialPosition.x, initialPosition.y, initialPosition.z);

        }
        else
        {

            transform.position = new Vector3(Mathf.Sin(Time.time) * speed + initialPosition.x, initialPosition.y, initialPosition.z);

        }

        //コライダーを有効にするか非有効にするか

        if (setOff)
        {
            colliderOfGround.enabled = false;
        }
        if (!setOff)
        {
            colliderOfGround.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "PersonTag")
        {
            setOff = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PersonTag")
        {
            setOff = false;
        }
    }
}

	

