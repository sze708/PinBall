using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //画面の幅の取得
    private int w;
    
	// Use this for initialization
	void Start () {
        //HingeJointCompornent取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        this.w = Screen.width;

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

        //左矢印キーを押したとき左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //→
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);

        }

        // マウスの左クリックを押した時及びスマートフォンでタップした時、フリッパーを動かす
        /*クリックで確認作業のために実装したコード。スマートフォン動作環境を想定した場合エラーが出るのでコメントにする。
         
        if (Input.GetMouseButtonDown(0))
        {
            float xPos = Input.mousePosition.x;


            if(xPos<w * 0.5 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }else if (xPos > w * 0.5 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

        }


        // クリックを離した時及びスマートフォンでタップをやめた時に、フリッパーを元に戻す
        if (Input.GetMouseButtonUp(0))
        {
            SetAngle(this.defaultAngle);
        }

        */

        //タップの数を取得する
        //LogFormatはLog(String())と同じ、{0}は箱と考え、「,」以降が代入される。
        //1本指タッチしたときの下記結果は「タッチ数：1」
        Debug.LogFormat("タッチ数:{0}", Input.touchCount);

        //タッチした指のid定義        
        for (int i = 0; i < Input.touchCount; i++)
        {
            Debug.LogFormat("{0}: {1}", i, Input.touches[i].fingerId);

        }

        //タッチ座標取得
        for (int i = 0; i < Input.touchCount; i++)
        {
            var id = Input.touches[i].fingerId;
            var xPos = Input.touches[i].position.x;
            Debug.LogFormat("{0} - x:{1}", id, xPos);


            //取得したタッチ座標を使い、左だったら左フリッパー、右なら右フリを動かす


            if (xPos < w * 0.5 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            else if (xPos > w * 0.5 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            else
            {
                SetAngle(this.defaultAngle);
            }

        }


        //タッチ状態の取得
        /*フリッパー動かすだけならいらないか？
        foreach (Touch t in Input.touches)
        {
            var id = t.fingerId;

            switch (t.phase)
            {
                case TouchPhase.Began:
                    Debug.LogFormat("{0}:いまタッチした", id);
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Debug.LogFormat("{0}:タッチしている", id);　//stationary：静止、デバッグログが増えまくるので併記
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    Debug.LogFormat("{0}:いま離された", id);
                    break;
            }
        }

          */



        }

    

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
