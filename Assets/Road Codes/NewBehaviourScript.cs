using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent("RoadBending") == null)
            return;
        RoadBending roadBending = (RoadBending)collider2D.GetComponent("RoadBending");
        this.transform.position = roadBending.positions[0] + roadBending.transform.position + new Vector3(0, 0, -0.1f);
        volacity = this.GetComponent<Rigidbody2D>().velocity.SqrMagnitude();
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        lastPositionReached = 0;
        endNavigation = false;
    }

    int lastPositionReached;
    float volacity;
    bool endNavigation = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (endNavigation)
            return;

        if (collision.GetComponent("RoadBending") == null)
        {
            Debug.Log("null road");
            return;
        }
        RoadBending roadBending = (RoadBending)collision.GetComponent("RoadBending");
        //if (!EqualPoints2D(this.transform.position , roadBending.positions[lastPositionReached] + roadBending.transform.position))
        //{
        //    return;
        //}
        if (roadBending.positions.Length == lastPositionReached+1)
        {
            Debug.Log("End road" + roadBending.name);
            endNavigation = true;
            return;
        }
        if (!EqualPoints2D(this.transform.position, roadBending.positions[lastPositionReached] + roadBending.transform.position))
        {
            return;
        }
        lastPositionReached++;

        Debug.Log("next point" + lastPositionReached );

        

        //Debug.Log("calc volacity");

        Vector2 direction = (roadBending.positions[lastPositionReached] + roadBending.transform.position - this.transform.position);
        direction.Normalize();
        //Debug.Log(direction.x + "*" + volacity + " , " + direction.y + "*" + volacity);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * volacity, direction.y * volacity);

    }

    bool EqualPoints2D(Vector3 p1, Vector3 p2)
    {
        if (Mathf.Abs(p1.x - p2.x) < 0.01 && Mathf.Abs(p1.y - p2.y) < 0.01)
        {
            Debug.Log("Equal" + p1 + p2);
            return true;
        }
        //Debug.Log("! " + p1 + p2);

        return false;
    }

}
