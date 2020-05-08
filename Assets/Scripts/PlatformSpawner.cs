using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    Vector3 lastPosition;
    float size;
    public GameObject platform;
    public GameObject diamond;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i = 0; i < 25; i++)
        {
            SpawnPlatforms();
        }      
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    // 
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 2f, 0.3f);
    }


    // randomly create paltforms on X or Z axis.
    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    // spawn in X direction
    void SpawnX()
    {
        Vector3 pos = lastPosition;
        pos.x += size;
        lastPosition = pos;

        // create platform through instantiation
        // quaternion.identity means no rotation and keep it in the same position we want.
        Instantiate(platform, pos, Quaternion.identity);

        // generate Diamonds randomly on the X direction platforms
        int diamondRandom = Random.Range(0, 4);

        if(diamondRandom == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, (pos.y + 1), pos.z), diamond.transform.rotation);
        }
    }

    // spawn in Y direction
    void SpawnZ()
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        lastPosition = pos;

        // create platform through instantiation
        // quaternion.identity means no rotation and keep it in the same position we want.
        Instantiate(platform, pos, Quaternion.identity);

        // generate Diamonds randomly on the platforms
        int diamondRandom = Random.Range(0, 4);
        if (diamondRandom == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, (pos.y + 1), pos.z), diamond.transform.rotation);
        }
    }
}
