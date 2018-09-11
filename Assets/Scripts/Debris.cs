using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : Hazard
{
	private void Update ()
    {
        int random = Random.Range(0, 9);

        transform.Rotate(new Vector3(0, 0, random));
	}
}
