using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    [SerializeField] int spawnNum = 1;
    public float radius = 1;
    public void SpawnPikmin(WolfNav wolf, ref List<WolfNav> pikminList)
    {
        for (int i = 0; i < spawnNum; i++)
        {
            WolfNav newPikmin = Instantiate(wolf);
            newPikmin.transform.position = transform.position + (Random.insideUnitSphere * radius);
            pikminList.Add(newPikmin);
        }
    }
}

