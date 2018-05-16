using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreate : MonoBehaviour {
    public GameObject ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(ball, transform.position, Quaternion.identity);
            ball.transform.Rotate(new Vector3(0, transform.rotation.y, 0));
            transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}
