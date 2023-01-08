using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealtText : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    public void ShowHealth(int health)
    {
        healthText.text = ""+health;
    }
}
