using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;
    // Start is called before the first frame update
    private int i;
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        //check distance platform and point
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //increase index
            if(i == points.Length) //check if platform was on last point
            {
                i = 0; //reset
            }
        }
        //moving platform to point with index i
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, 
            speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
