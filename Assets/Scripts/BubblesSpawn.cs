using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesSpawn : MonoBehaviour
{

    public GameObject[] spheres;
    public GameObject offset;

    public static float radius; // By User
    // public static float radiuss;
    private float yCenter;
    private float xCenter;

    public static float time;  // By User

    private float timer = 0;
    public static List<Vector3> usedPositions = new List<Vector3>();

    public static bool yDestroyed = false;
    public static bool rDestroyed = false;
    // ShowKeyboard keyboard;

    public static int badRatio;  // By User

    // Start is called before the first frame update
    void Start()
    {
        ShowKeyboard.LoadParameters();

        yCenter = offset.transform.position.y;
        xCenter = offset.transform.position.x;

        SpawnRandomBubbles(5 - badRatio, badRatio);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= time && yDestroyed){
            SpawnRandomBubbles(1, 0);
            yDestroyed = false;
        }
        else if(timer <= time && rDestroyed){
            SpawnRandomBubbles(0, 1);
            rDestroyed = false;
        }
        timer += Time.deltaTime;
    }

    void SpawnRandomBubbles(int yBubblesNum, int rBubblesNum){
        if(yBubblesNum > 0)
            CreateBubble(yBubblesNum, 0);
        if(rBubblesNum > 0)
            CreateBubble(rBubblesNum, 1);
    }

    void CreateBubble(int bubblesNum, int index){
        for(int i = 0; i < bubblesNum; i++){
            Vector3 spawnPos = new Vector3(Random.Range(xCenter - radius, xCenter + radius), Random.Range(0, yCenter + radius), 1);
            if(usedPositions.Contains(spawnPos))
                continue;
            Instantiate(spheres[index], spawnPos, spheres[index].transform.rotation);
            usedPositions.Add(spawnPos);
        }
    }
}
