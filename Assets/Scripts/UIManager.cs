using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Shelter[] shelters;
    public Text[] shelterText;
    public Text hazardCountText;

    private int hazardDeathCount;

    // Singleton!
    public static UIManager Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    private void Update()
    {
        // Actualiza la resistencia de los shelters en el UI
        for (int i = 0; i < shelters.Length; i++)
        {
            shelterText[i].text = "Shelter " + (i+1).ToString() + ":" + shelters[i].resistance.ToString();
        }
    }

    public void IncreaseHazardCount()
    {
        hazardDeathCount++;

        hazardCountText.text = "Hazards: " + hazardDeathCount.ToString();
    }
}
