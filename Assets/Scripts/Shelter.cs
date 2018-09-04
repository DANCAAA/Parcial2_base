using UnityEngine;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;

    int regentTime = 0;

    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    //Impact rest points
    private void OnCollisionEnter2D(Collision2D collision)
    {
        maxResistance = maxResistance - 1;
        regenTime();
    }

    //If the resistence is 0 destroy shelter
    public void Damage(int damage)
    {
       if(maxResistance == 0)
        {
            Debug.Log("Game over");
            Destroy(this);
        }
    }

    void regenTime()
    {
        regentTime = regentTime + 1;
    }

    private void Update()
    {
       
    }
}