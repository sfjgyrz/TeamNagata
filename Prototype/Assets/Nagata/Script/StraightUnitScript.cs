using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightUnitScript : MonoBehaviour {
    Animator SUanimator;
    Vector3 PelsonaPos;
    float FirstAgree = 180;
    float lotetyme = 0;
    int flagint = 0;
    Quaternion Lote1= Quaternion.Euler(0, 180, 0);
    bool firstlotateflag = true;//アニメーション１の起動が初回であるかどうかのフラグ
    bool loteteflag1 = false;//アニメーション１が起動されるとtrueになる処理。
    bool loteteflag2 = false;//アニメーション2が起動されるとtrueになる処理。
    bool loteteflag3 = false;//アニメーション3が起動されるとtrueになる処理。
    bool loteteflag4 = false;//アニメーション4が起動されるとtrueになる処理。
    bool SUAccessflag;//マウスがStrightUnitの位置に接触している場合。
    bool islotateflag = false;
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
        PelsonaPos = this.transform.position;
        SUanim = this.gameObject.GetComponent<Animation>();
        SUanimator = GetComponent<Animator>();
    }
	public void Lote1Contlole()
    {
        islotateflag = true;
        if (lotetyme < 1)
        {
            lotetyme += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Lote1, lotetyme);
            islotateflag = false;
        }
    }

	// Update is called once per frame
	void Update () {

        switch (flagint)
        {
            case 1:
                Lote1Contlole();
                break;
        }
        
        if (Input.GetMouseButtonDown(0) && SUAccessflag == true)//一本道のコライダーにマウスがいるとき、マウスの左クリックが押された場合
        {
          
            if (flagint==0&&islotateflag==false)
            {
                flagint = 1;
            }
            if (flagint==1&&islotateflag==false)
            {
                flagint = 2;
            }
            if (flagint==2&&islotateflag==false)
            {
                flagint = 3;
            }
            if (flagint==3&&islotateflag==false)
            {
                flagint = 4;
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
