using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//衝突時のスコア加算変数
	//private int Score = 0;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;


	//スコアを表示する変数
	private GameObject  ScorelogH;
	private int Scorelog = 0;


	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		//シーン中のScorelogHオブジェクトを取得
		this.ScorelogH = GameObject.Find ("Scorelog");
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		
		//Debug.Log("OnCollisionEnterが呼ばれたよ");

		if (other.gameObject.tag == "SmallStarTag") {
			//小さい星のスコア加算
			//Score += 20;
			//Debug.Log("SmallStarTagと接触したよ");
			Scorelog += 20;
		}else if(other.gameObject.tag == "LargeStarTag"){
			//大きい星のスコア加算
			//Score += 5;
			Scorelog += 5;
		}else if(other.gameObject.tag == "SmallCloudTag"){
			//小さい雲のスコア加算
			//Score += 10;
			Scorelog += 10;
		}else if(other.gameObject.tag == "LargeCloudTag"){
			//大きい雲のスコア加算
			//Score += 1;
			Scorelog += 1;
		}
	}

	// Update is called once per frame
	void Update () {

		//表示されるスコア
		this.ScorelogH.GetComponent<Text> (). text = Scorelog.ToString();

		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}
}
