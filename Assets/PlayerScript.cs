using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public int speed = 5;
	//base speed/second
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
        //KEYBOARD INPUT
        if (Input.GetKey(KeyCode.LeftArrow))//if left arrow key is pressed down
        {
            xDir = -1;
			//x component of direction vector is -1
        }
		else if (Input.GetKey(KeyCode.RightArrow))//if right arrow key is pressed down
        {
            xDir = 1;
			//x component of direction vector is 1
        }
		if (Input.GetKey(KeyCode.UpArrow))//if up arrow key is pressed down
        {
            yDir = 1;
			//y component of direction vector is 1
        }
		else if (Input.GetKey(KeyCode.DownArrow))//if down arrow key is pressed down
        {
            yDir = -1;
			//y component of direction vector is -1
        }




		//PLAYER MOVEMENT
        float adjustedSpeed = speed * Time.fixedDeltaTime;
        //speed adjusts every frame, where the new speed is equal to (base speed/second * seconds taken to load frame)
		//basically returns the distance at which the new player should move according to speed and time passed, d=vt

        transform.Translate(new Vector3(xDir * adjustedSpeed, yDir * adjustedSpeed, 0));
		//translates (moves) player according to the adjusted speed in accordance to directions dictated by key presses, stored in 2D unit vector [xDir, yDir]




		//CAMERA MOVEMENT
        float distance = Vector2.Distance((Vector2)transform.position, (Vector2)cam.transform.position);
		//calculates distance, which is the magnitude of distance betweeen the player's position and the position of the camera
        /*
		if (xDir == 0 && yDir == 0)//centers the camera when player isn't moving
        {
            if (distance > adjustedSpeed * .9)//when camera is far from the player
            {
                Vector2 travelDir = cam.transform.position - transform.position;
				//finds vector from player to camera
                travelDir.Normalize();
				//set magnitude of vector of player to camera to 1
                cam.transform.Translate(new Vector3(-travelDir.x * adjustedSpeed, -travelDir.y * adjustedSpeed, 0));
				//moves the camera closer to player
            }
            else//when camera is very close to the player
            {
                cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
				//sets the camera position to the player position 
            }
        }

		//if the player is moving
        else if (distance < maxDistance && distance > maxDistance *.9)//
        {
            cam.transform.Translate(new Vector3(xDir *2* adjustedSpeed, yDir *2* adjustedSpeed, 0));
        }
        else if (distance < (2 * maxDistance))
        {
            cam.transform.Translate(new Vector3(xDir * 3 * adjustedSpeed, yDir* 3 * adjustedSpeed, 0));
        }
		else if (distance >= (2 * maxDistance))
        {
            cam.transform.Translate(new Vector3(xDir * adjustedSpeed, yDir * adjustedSpeed, 0));
        }*/


		//CAMERA MOVEMENT V2
		float camTightness = 20;
		//how close the camera tracks the character
		//the higher the number the less tightly the camera follows the character; at 1 the camera moves with the character


		Vector2 travelDir = cam.transform.position - transform.position;
		//finds vector from player to camera
		cam.transform.Translate (new Vector3 (-travelDir.x / camTightness, -travelDir.y / camTightness, 0));
		//moves the camera closer to player according to distance between camera and player

		int leftBound = -2;
		int rightBound = 10;
		int upperBound = -2;
		int lowerBound = 10;
		//Boundary values for left, right up and down

		if (cam.transform.position.x < leftBound) {
			cam.transform.position = new Vector3(leftBound, cam.transform.position.y, cam.transform.position.z);
		}
		//sets left boundary for camera
		if (cam.transform.position.x > rightBound) {
			cam.transform.position = new Vector3(rightBound, cam.transform.position.y, cam.transform.position.z);
		}
		//sets left boundary for camera
		if (cam.transform.position.y < upperBound) {
			cam.transform.position = new Vector3(cam.transform.position.x, upperBound, cam.transform.position.z);
		}
		//sets left boundary for camera
		if (cam.transform.position.y > lowerBound) {
			cam.transform.position = new Vector3(cam.transform.position.x, lowerBound, cam.transform.position.z);
		}
		//sets left boundary for camera



		//DIRECTION VECTOR
        xDir = 0;
        yDir = 0;
		//Resets direction vector for next frame
    }
}
