using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] WallScript[] walls;
    
    public void DestroyWalls()
    {
        for(int i = 0; i < walls.Length; i++)
        {
            walls[i].StartFadeOut();
        }
    }
}
