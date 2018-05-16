using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightUnitScript : MonoBehaviour {
    Animator SUanimator;
    bool firstlotateflag = true;//アニメーション１の起動が初回であるかどうかのフラグ
    bool loteteflag1= false;//アニメーション１が起動されるとtrueになる処理。
    bool loteteflag2 = false;//アニメーション2が起動されるとtrueになる処理。
    bool loteteflag3 = false;//アニメーション3が起動されるとtrueになる処理。
    bool loteteflag4 = false;//アニメーション4が起動されるとtrueになる処理。
    bool SUAccessflag;//マウスがStrightUnitの位置に接触している場合。
    Animation SUanim;
    // Use this for initialization
    IEnumerator Loteteflag1Diley()//左クリックが押された１秒後にloteteflag1がtrueになる処理
    {
        yield return new WaitForSeconds(LtypeUnitLotateScript.Unitlotatespeed);  //10秒待つ
        loteteflag1 = true;

    }
    IEnumerator Loteteflag2Diley()//左クリックが押された１秒後にloteteflag2がtrueになる処理
    {
        yield return new WaitForSeconds(LtypeUnitLotateScript.Unitlotatespeed);  //10秒待つ
        loteteflag2 = true;

    }
    IEnumerator Loteteflag3Diley()//左クリックが押された１秒後にloteteflag3がtrueになる処理
    {
        yield return new WaitForSeconds(LtypeUnitLotateScript.Unitlotatespeed);  //10秒待つ
        loteteflag3 = true;

    }
    IEnumerator Loteteflag4Diley()//左クリックが押された１秒後にloteteflag4がtrueになる処理
    {
        yield return new WaitForSeconds(LtypeUnitLotateScript.Unitlotatespeed);  //10秒待つ
        loteteflag4 = true;

    }
    IEnumerator LastTurn()//左クリックが押された１秒後にloteteflag4がtrueになる処理
    {      
        yield return new WaitForSeconds(LtypeUnitLotateScript.Unitlotatespeed);  //10秒待つ
        loteteflag2 = false;
        loteteflag3 = false;
        loteteflag4 = false;

    }

    void Start () {
		SUanim= this.gameObject.GetComponent<Animation>();
        SUanimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && SUAccessflag == true)//一本道のコライダーにマウスがいるとき、マウスの左クリックが押された場合
        {
          
            if (loteteflag1 == false && loteteflag2 == false && loteteflag3 == false && loteteflag4 == false&&firstlotateflag==true)
            {
                SUanimator.SetInteger("SUControllint", 1);
                StartCoroutine("Loteteflag1Diley");
                firstlotateflag = false;
            }
            if (loteteflag1 == true && loteteflag2 == false && loteteflag3 == false && loteteflag4 == false)
            {
                SUanimator.SetInteger("SUControllint", 2);
                StartCoroutine("Loteteflag2Diley");
            }
            if (loteteflag1 == true && loteteflag2 == true && loteteflag3 == false && loteteflag4 == false)
            {
                SUanimator.SetInteger("SUControllint", 3);
                StartCoroutine("Loteteflag3Diley");
            }
            if (loteteflag1 == true && loteteflag2 == true && loteteflag3 == true && loteteflag4 == false)
            {
                SUanimator.SetInteger("SUControllint", 4);
                StartCoroutine("Loteteflag4Diley");
            }
            if (loteteflag1 == true && loteteflag2 == true && loteteflag3 == true && loteteflag4 == true)
            {
                SUanimator.SetInteger("SUControllint", 0);
                StartCoroutine("LastTurn");
            }

        }
	}
    public void AccessSU()//マウスが一本道のコライダーに入った時
    {
        SUAccessflag = true;
        Debug.Log(SUAccessflag);

    }
    public void EscapeSU()//マウスが一本道のコライダーより離れたとき
    {
        SUAccessflag = false;
        Debug.Log(SUAccessflag);
    }
}
