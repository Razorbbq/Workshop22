using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeysCollected : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] DoorScript door;

    int currentKeys = 0;
    [SerializeField] int maxKeys = 3;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        text.text = $"{currentKeys}/{maxKeys}";
    }
    public void AddKey()
    {
        currentKeys++;

        if(currentKeys >= maxKeys)
        {
            door.DestroyWalls();
        }
        UpdateText();
    }


}
