using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject moveStagePrefab;

    public GameObject enemyPrefab;

    //スタートポジション
    private float startPos = 1.5f;

    //ゴールポジション
    private float goalPos = 100;

    // Use this for initialization
    void Start() {

        
        //2上がるごとにアイテムを生成
        for (float i = startPos; i < goalPos; i += 2)
        {
            //ステージの位置をx軸方向にランダムに設定
            int offsetX = Random.Range(-2, 2);

            　　//ステージを生成
                GameObject moveStage = Instantiate(moveStagePrefab) as GameObject;
                moveStage.transform.position = new Vector3(offsetX, i, moveStage.transform.position.z);

            //敵を○○%の確率でランダムに生成
            int num = Random.Range(0, 10);

            if(num < 2)
            {
                GameObject enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(num, i+1, enemy.transform.position.z);
            }
        }



    }
    
        

	
	
	// Update is called once per frame
	void Update () {
		
	}
}
