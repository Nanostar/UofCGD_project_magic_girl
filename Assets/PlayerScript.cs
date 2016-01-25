using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public int speed = 5;
    public float maxDistance = 1.5f;
    CameraScript cam;
    int xDir = 0, yDir = 0;
    // Use this for initialization
    void Start () {
        cam = FindObjectOfType<CameraScript>() as CameraScript;
	}
	
	// Update is called once per frame
	void Update () {


    }
    void FixedUpdate()
    {
        //keyboard input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xDir = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
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
        float adjustedSpeed = speed * Time.fixedDeltaTime;
        //character movement
        transform.Translate(new Vector3(xDir * adjustedSpeed, yDir * adjustedSpeed, 0));
        float distance = Vector2.Distance((Vector2)transform.position, (Vector2)cam.transform.position);
        //camera movement

        if (xDir == 0 && yDir == 0)
        {
            //centering the camera when player isn't moving
            if (distance > adjustedSpeed * .9)
            {
                Vector2 travelDir = cam.transform.position - transform.position;
                travelDir.Normalize();
                cam.transform.Translate(new Vector3(-travelDir.x * adjustedSpeed, -travelDir.y * adjustedSpeed, 0));
            }
            else
            {
                cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
            }

        }
        else if (distance < maxDistance && distance > maxDistance *.9)
        {
            cam.transform.Translate(new Vector3(xDir *2* adjustedSpeed, yDir *2* adjustedSpeed, 0));
        }
        else if (distance < (2 * maxDistance))
        {
            cam.transform.Translate(new Vector3(xDir * 3 * adjustedSpeed, yDir* 3 * adjustedSpeed, 0));
        }else if (distance >= (2 * maxDistance))
        {
            cam.transform.Translate(new Vector3(xDir * adjustedSpeed, yDir * adjustedSpeed, 0));
        }
        xDir = 0;
        yDir = 0;
    }
}
