using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{

    [SerializeField] int width, height;
    [SerializeField] GameObject dirt, grass, stone;

    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    void Generation()
    {
        for(int x = 0; x < width; x++)
        {
            int minHeight = height - 1;
            int maxHeight = height + 2;
            height = Random.Range(minHeight, maxHeight);
            int minStoneSpawnDistance = height - 10;
            int maxStoneSpawnDistance = height - 20;
            int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);
            for (int y = 0; y<height; y++)
            {
                if(y<totalStoneSpawnDistance)
                {
                    spawnObj(stone, x, y);
                }
                else
                {
                    spawnObj(dirt, x, y);
                }
            }
            spawnObj(grass, x, height);
        }
    }

    void spawnObj(GameObject obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
