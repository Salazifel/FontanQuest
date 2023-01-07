using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateResources : MonoBehaviour
{
    public TextMeshProUGUI Wood;
    public TextMeshProUGUI Stone;
    public TextMeshProUGUI Food;
    public TextMeshProUGUI Gold;

    // Start is called before the first frame update
    void Start()
    {
        Wood.text = ResourceContainer.Wood.ToString();
        Stone.text = ResourceContainer.Stone.ToString();
        Food.text = ResourceContainer.Food.ToString();
        Gold.text = ResourceContainer.Gold.ToString();
    }
}
