using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // 変数宣言
    int key = 0;    // コントローラのキーの入力
    float speed = 0.03f;
    string state;   //アニメの状態

    // コンポーネント宣言
    Animator _anim; // プレイヤーアニメ

	// Use this for initialization
	void Start () {
        //プレイヤーに設定されたAnimator呼び出し
		_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        // 入力処理
        GetInputKey();
        // アニメ切り替え
        ChangeAnim();
        // 移動
        Move();

    }
    /// <summary>
    /// アニメの管理
    /// </summary>
    void ChangeAnim()
    {
        // アニメの状態
        switch(state)
        {
            case "Idle":
                _anim.SetBool("isIdle",true);
                _anim.SetBool("isRun",false);
                break;
            case "Run":
                _anim.SetBool("isRun",true);
                _anim.SetBool("isIdle",false);
                break;
        }
    }


    /// <summary>
    /// 入力処理
    /// </summary>
    void GetInputKey()
    {
        key = 0;
        // もし左キーが押されていたら
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;   // 左キーが押されている
        }
        // もし右キーが押されていたら
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;    // 右キーが押されている
        }
    }

    void Move()
    {
        this.transform.position += new Vector3(key*speed, 0, 0);
    }
}
