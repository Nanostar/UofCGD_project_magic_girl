using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public int speed = 5;
    public float MaxDistance = 1.5f;
    CameraScript cam;
    // Use this for initialization
    void Start () {
        cam = FindObjectOfType<CameraScript>() as CameraScript;
	}
	
	// Update is called once per frame
	void Update () {
        int xDir = 0 , yDir = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xDir = -1;   
            
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            xDir = 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yDir = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            yDir = -1;
        }
        transform.Translate(new Vector3(xDir * speed * Time.deltaTime, yDir*speed * Time.deltaTime, 0));
        float distance = Vector2.Distance(transform.position, cam.transform.position);
        if (distance > MaxDistance)
        {
            cam.transform.Translate(new Vector3(xDir * speed * Time.deltaTime, yDir * speed * Time.deltaTime, 0));
        }
    }
}
