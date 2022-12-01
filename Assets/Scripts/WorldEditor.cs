using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEditor : MonoBehaviour
{
    public MapGenerator mapGen;

    private void Start()
    {
        mapGen.GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("-"))
        {
            mapGen.meshHeightMutiplier -= 0.1f;
            mapGen.GenerateMap();
        }
        else if (Input.GetKey("="))
        {
            mapGen.meshHeightMutiplier += 0.1f;
            mapGen.GenerateMap();
        }

        if (Input.GetKey("["))
        {
            mapGen.noiseScale -= 0.1f;
            mapGen.GenerateMap();
        }
        else if (Input.GetKey("]"))
        {
            mapGen.noiseScale += 0.1f;
            mapGen.GenerateMap();
        }

        if (Input.GetKey("up"))
        {
            mapGen.offset.x -= 0.1f;
            mapGen.GenerateMap();
        }
        else if (Input.GetKey("down"))
        {
            mapGen.offset.x += 0.1f;
            mapGen.GenerateMap();
        }

        if (Input.GetKey("left"))
        {
            mapGen.offset.y += 0.1f;
            mapGen.GenerateMap();
        }
        else if (Input.GetKey("right"))
        {
            mapGen.offset.y -= 0.1f;
            mapGen.GenerateMap();
        }

        if (Input.GetKeyDown("o"))
        {
            mapGen.octaves -= 1;
            mapGen.GenerateMap();
        }
        else if (Input.GetKeyDown("p"))
        {
            mapGen.octaves += 1;
            mapGen.GenerateMap();
        }

        if (Input.GetKey("k"))
        {
            mapGen.persistance -= 0.001f;
            mapGen.GenerateMap();
        }
        else if (Input.GetKey("l"))
        {
            mapGen.persistance += 0.001f;
            mapGen.GenerateMap();
        }

        if(mapGen.persistance >= 1)
        {
            mapGen.persistance = 1;
        }
        else if (mapGen.persistance <= 0)
        {
            mapGen.persistance = 0;
        }

        if (Input.GetKey(","))
        {
            mapGen.lacunarity -= 0.05f;
            mapGen.GenerateMap();
        }
        else if (Input.GetKey("."))
        {
            mapGen.lacunarity += 0.05f;
            mapGen.GenerateMap();
        }
    }
}
