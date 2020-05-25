using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalaAdCaelum : MonoBehaviour {

    public GameObject[] buildings;
    public GameObject[] towerTops;
    public int mapWidth = 5;
    public int mapHeight = 5;

    public int minTowerDist = 1;
    public int buildingFootprint = 3; // Assuming building are cubes and this defines length of side
    public int radius = 10; // Radius of bottom most layer
    public int angleMul = 10;

    // Start is called before the first frame update
    void Start() {
       // Place random towers in grid pattern
       for(int h = 0; h < mapHeight; h++) {
            for(int w = 0; w < mapWidth; w++) {
                Vector3 pos = new Vector3(w * minTowerDist, 0, h * minTowerDist);
                ProduceTower(pos);
            }
        }
    }

    private void ProduceTower(Vector3 origin) {
        // Make the base of the tower
        for(int i = 0; i < radius - 3; i++) {
            float curRad = radius - i;
            // Rotate around origin
            for(int j = 0; j < 360; j += (i+1)*angleMul) {
                // Start from origin and slowly move out to radius
                for(int k = 0; k < curRad; k += buildingFootprint/2){ 
                    // Calculate direction and position of building
                    Vector3 dir = new Vector3(k, 0, k);
                    dir = Quaternion.Euler(new Vector3(0, j, 0)) * dir;
                    Vector3 pos = dir + origin;
                    pos.y = i * buildingFootprint;

                    // Make a random building
                    int n = Random.Range(0, buildings.Length);
                    GameObject g = Instantiate(buildings[n], pos, Quaternion.identity);
                    Vector3 temp = origin;
                    temp.y += i * buildingFootprint;
                    g.transform.LookAt(temp);
                }
            }
        }

        // Add random tower tip
        origin.y = (radius - 3) * buildingFootprint;
        int r = Random.Range(0, towerTops.Length);
        Instantiate(towerTops[r], origin, Quaternion.identity);
    }
}
