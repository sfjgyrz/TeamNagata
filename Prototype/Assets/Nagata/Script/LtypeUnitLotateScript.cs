using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LtypeUnitLotateScript : MonoBehaviour {
    Animator LUanimator;
    Vector3 pos;
    public static float Unitlotatespeed=1.0f;
    bool firstlotateflag = true;//アニメーション１の起動が初回であるかどうかのフラグ
    bool loteteflag1 = false;//アニメーション１が起動されるとtrueになる処理。
    bool loteteflag2 = false;//アニメーション2が起動されるとtrueになる処理。
    bool loteteflag3 = false;//アニメーション3が起動されるとtrueになる処理。
    bool loteteflag4 = false;//アニメーション4が起動されるとtrueになる処理。
    bool LUAccessflag;//マウスがStrightUnitの位置に接触している場合。
    Animation LUanim;
    // Use this for initialization
    IEnumerator Loteteflag1Diley()//左クリックが押された１秒後にloteteflag1がtrueになる処理
    {
        yield return new WaitForSeconds(Unitlotatespeed);  //10秒待つ
        loteteflag1 = true;

    }
    IEnumerator Loteteflag2Diley()//左クリックが押された１秒後にloteteflag2がtrueになる処理
    {
        yield return new WaitForSeconds(Unitlotatespeed);  //10秒待つ
        loteteflag2 = true;

    }
    IEnumerator Loteteflag3Diley()//左クリックが押された１秒後にloteteflag3がtrueになる処理
    {
        yield return new WaitForSeconds(Unitlotatespeed);  //10秒待つ
        loteteflag3 = true;

    }
    IEnumerator Loteteflag4Diley()//左クリックが押された１秒後にloteteflag4がtrueになる処理
    {
        yield return new WaitForSeconds(Unitlotatespeed);  //10秒待つ
        loteteflag4 = true;

    }
    IEnumerator LastTurn()//左クリックが押された１秒後にloteteflag4がtrueになる処理
    {
        yield return new WaitForSeconds(Unitlotatespeed);  //10秒待つ
        loteteflag2 = false;
        loteteflag3 = false;
        loteteflag4 = false;

    }

    void Start()
    {
        pos = transform.position;
        LUanim = this.gameObject.GetComponent<Animation>();
        LUanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && LUAccessflag == true)//一本道のコライダーにマウスがいるとき、マウスの左クリックが押された場合
        {

            if (loteteflag1 == false && loteteflag2 == false && loteteflag3 == false && loteteflag4 == false && firstlotateflag == true)
            {
                LUanimator.SetInteger("LUflagint", 1);
                StartCoroutine("Loteteflag1Diley");
                firstlotateflag = false;
            }
            if (loteteflag1 == true && loteteflag2 == false && loteteflag3 == false && loteteflag4 == false)
            {
                LUanimator.SetInteger("LUflagint", 2);
                StartCoroutine("Loteteflag2Diley");
            }
            if (loteteflag1 == true && loteteflag2 == true && loteteflag3 == false && loteteflag4 == false)
            {
                LUanimator.SetInteger("LUflagint", 3);
                StartCoroutine("Loteteflag3Diley");
            }
            if (loteteflag1 == true && loteteflag2 == true && loteteflag3 == true && loteteflag4 == false)
            {
                LUanimator.SetInteger("LUflagint", 4);
                StartCoroutine("Loteteflag4Diley");
            }
            if (loteteflag1 == true && loteteflag2 == true && loteteflag3 == true && loteteflag4 == true)
            {
                LUanimator.SetInteger("LUflagint", 0);
                StartCoroutine("LastTurn");
            }

        }
    }
    public void AccessLU()//マウスが一本道のコライダーに入った時
    {
        LUAccessflag = true;
        Debug.Log(LUAccessflag);

    }
    public void EscapeLU()//マウスが一本道のコライダーより離れたとき
    {
        LUAccessflag = false;
        Debug.Log(LUAccessflag);
    }
}