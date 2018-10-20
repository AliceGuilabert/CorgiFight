using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xmin, xmax, ymin, ymax;
}

public class Engine : MonoBehaviour {
    private Vector2 position;
    BaseAvatar myBase;
    InputManager myInput;

    [SerializeField]
    private Boundary myBound;

    public Vector2 GetMyPosition()
    {
        return transform.position;
    }
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    // Use this for initialization
    void Start () {
        myBase = GetComponent<BaseAvatar>();		
	}

    public void move(Vector2 speed, float angle) {

        if(angle < 0)
        {
            Vector3 Newposition = GetMyPosition() + new Vector2(speed[0] * myBase.getMaxSpeed() * Time.deltaTime,
            speed[1] * myBase.getMaxSpeed() * Time.deltaTime);

             SetPosition(new Vector2(Mathf.Clamp(Newposition[0], myBound.xmin, myBound.xmax),
             Mathf.Clamp(Newposition[1], myBound.ymin, myBound.ymax)));

        }
        else
        {
            Vector3 Newposition = GetMyPosition() + new Vector2(speed[0] * myBase.getMaxSpeed() *Time.deltaTime,
            speed[1] * myBase.getMaxSpeed()* Mathf.Sin(angle * Time.time)* Time.deltaTime);

            SetPosition(new Vector2(Mathf.Clamp(Newposition[0], myBound.xmin, myBound.xmax),
            Mathf.Clamp(Newposition[1], myBound.ymin, myBound.ymax)));
        }
    }

    
}