using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour {

    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int buildingFootprint = 3;

    // Start is called before the first frame update
    void Start() {

        float seed = Random.Range(0, 100);

        for(int h = 0; h < mapHeight; h++) {
            for(int w = 0; w < mapWidth; w++) {
                int result = (int) (Mathf.PerlinNoise(w/10.0f + seed, h/10.0f + seed) * 10);
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);
                //int n = Random.Range(0, buildings.Length);
                //Instantiate(buildings[n], pos, Quaternion.identity);
                if(result < 2)       Instantiate(buildings[0], pos, Quaternion.identity);
                else if(result < 4)  Instantiate(buildings[1], pos, Quaternion.identity);
                else if(result < 6)  Instantiate(buildings[2], pos, Quaternion.identity);
                else if(result < 7)  Instantiate(buildings[3], pos, Quaternion.identity);
                else if(result < 8)  Instantiate(buildings[4], pos, Quaternion.identity);
                else if(result < 10) Instantiate(buildings[5], pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
