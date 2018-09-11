using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    public int resistance = 5;

    public float regentTime = 0;
    public float regenTimeCooldown = 5;

    private bool isInCooldown;

    // ***

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Shelter :: OnTriggerEnter2D");

        if (collision.gameObject.CompareTag("Invader") ||
            collision.gameObject.CompareTag("Debris") ||
            collision.gameObject.CompareTag("Hazard"))
        {
            SubstractResistance();

            if (isInCooldown)
            {
                StopCoroutine(StartRegenTime());

                isInCooldown = false;
            }
            else
            {
                StartCoroutine(StartRegenTime());

                isInCooldown = true;
            }
        } 
    }

    private void AddResistance()
    {
        Debug.Log("Shelter :: AddResistance");

        resistance++;
    }

    private void SubstractResistance()
    {
        Debug.Log("Shelter :: SubstractResistance");

        resistance--;
    }

    private IEnumerator StartRegenTime()
    {
        Debug.Log("Shelter :: StartRegenTime");

        while (regentTime <= regenTimeCooldown)
        {
            regentTime += Time.deltaTime;

            yield return null;
        }

        regentTime = 0;

        AddResistance();
    }
}