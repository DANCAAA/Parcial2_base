using UnityEngine;

public static class SpawnerExtensions
{
    public static Vector3 GetPointInVolume(this Collider2D collider)
    {
        Vector3 result = Vector3.zero;
        result = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), collider.transform.position.y, 0F);

        return result;
    }
}

[RequireComponent(typeof(Collider2D))]
public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform hazardParent;

    public Transform[] hazardSpawnPoints;

    private Collider2D myCollider;

    [SerializeField]
    private float spawnFrequency = 1F;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();

        InvokeRepeating("SpawnEnemy", 0.2F, spawnFrequency);
    }

    private void SpawnEnemy()
    {
        int r1 = Random.Range(0, hazardParent.childCount);
        while (hazardParent.GetChild(r1).gameObject.activeSelf)
        {
             r1 = Random.Range(0, hazardParent.childCount);
        }

        //Activa los hijos de hazard para spwnear crear o destruir
        if(hazardParent.GetChild(r1).gameObject.tag == "Invader")
        {
            hazardParent.GetChild(r1).gameObject.GetComponent<Invader>().move = true;
        }
        int r = Random.Range(0, hazardSpawnPoints.Length);
        hazardParent.GetChild(r1).gameObject.transform.position = hazardSpawnPoints[r].position;
        hazardParent.GetChild(r1).gameObject.SetActive(true);
    }
}