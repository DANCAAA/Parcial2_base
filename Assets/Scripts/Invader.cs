using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : Hazard
{
    public bool move;
    private float angle;
    private float xpos;
    private int time;

    private void OnEnable()
    {
        xpos = transform.position.x;
    }

    private void Update()
    {
        if (move)
        {
            transform.position = new Vector3(xpos + Mathf.Sin(angle) * 1, transform.position.y, 0);
            angle += 0.1f;
        }
        else
        {
            int r = Random.Range(0, 9);

            transform.Rotate(new Vector3(0, 0, r));
            time++;

            if (time > 30)
            {
                time = 0;
               
                gameObject.SetActive(false);
            }
        }
	}
}
