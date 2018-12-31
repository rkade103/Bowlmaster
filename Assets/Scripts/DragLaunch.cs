using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private bool launched = false;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}

    public void DragStart()
    {
        //Capture time and position of mouse click
        startTime = Time.time;
        dragStart = Input.mousePosition;

    }

    public void DragEnd()
    {
        endTime = Time.time;
        dragEnd = Input.mousePosition;

        float dragDuration = endTime - startTime;
        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        //We use dragEnd.y because that is where the mouse input.
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        ball.Launch(launchVelocity);
        launched = true;
    }

    public void MoveStart(float xNudge)
    {
        if (!launched)
        {
            float newPosX = ball.transform.position.x + xNudge;
            if(newPosX > 52.5f)
            {
                newPosX = 52.5f;
            }
            else if (newPosX < -52.5f)
            {
                newPosX = -52.5f;
            }
            ball.transform.position = new Vector3 (newPosX, ball.transform.position.y, ball.transform.position.z);
        }
        Debug.Log("Nudge it by " + xNudge.ToString());
    }
}
