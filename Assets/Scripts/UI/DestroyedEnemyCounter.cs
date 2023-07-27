using UnityEngine;
using TMPro;

public class DestroyedEnemyCounter : MonoBehaviour
{
    [SerializeField] TMP_Text destroyedUFOText;
    [SerializeField] TMP_Text destroyedMeteoritesText;
    private int destroyedMeteorites;
    private int destroyedUFO;

    public void ShowNumberOfDestroyedEnemies()
    {
        destroyedMeteoritesText.text = "Destroyed meteorites " + destroyedMeteorites;
        destroyedUFOText.text = "Destroyed ufo " + destroyedUFO; 
    }

    public void AddDestroyedNumber(string name)
    {
        switch (name)
        {
            case "Meteorite":
                destroyedMeteorites++;
                break;
            case "ufo":
                destroyedUFO++;
                break;
            default:
                break;
        }
    }
}
