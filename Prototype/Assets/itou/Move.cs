using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    float speed = 0.05f;
    float timer = 0.0f;
    int count = 0;

    bool flag = false;

    void Start()
    {

    }

    void Update()
    {
        //向いている方向に移動
        transform.position += transform.TransformDirection(Vector3.forward) * speed;

        //壁に当たったら時間を計る
        if (flag == true)
        {
            timer += Time.deltaTime;
        }

        if (timer < 0.5 && count >= 4)
        {
            Destroy(gameObject);
        }

        //壁に当たってから0.1秒たったら時間を計ることをやめて、タイマーをリセット
        if (timer > 0.5)
        {
            flag = false;
            timer = 0;
            count = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //壁に当たったら向いている方向から90度回転(右を向く)し、タイマーを起動
        if (other.gameObject.tag == "Wall" && flag == false)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            flag = true;
            count++;
            Debug.Log("起動１");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //一度壁に当たってから0.01秒以内にまだ壁に当たっていた場合180回転（左を向く）
        if (other.gameObject.tag == "Wall" && flag == true && timer > 0.01)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            count++;
            Debug.Log("起動２");
        }
        //if (other.gameObject.tag == "Wall" && flag == true && timer < 0.5)
        //{
        //    transform.Rotate(new Vector3(0, 180, 0));
        //    Debug.Log("2_起動");
        //}
    }
}

