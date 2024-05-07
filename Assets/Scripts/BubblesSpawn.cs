using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesSpawn : MonoBehaviour
{

    public GameObject[] spheres;

    public GameObject superBubble;
    public GameObject offset;

    public GameObject resultsMenu;

    public static float radius; 
    private float yCenter;
    private float xCenter;

    public static float time;  

    private float timer = 0;
    public static List<Vector3> usedPositions = new List<Vector3>();

    private List<Vector3> superBubblesPositions = new List<Vector3>();

    public static bool yDestroyed = false;
    public static bool rDestroyed = false;

    public static int badRatio;  

    public static int superBubblesCount;

    // Start is called before the first frame update
    void Start()
    {
        ShowKeyboard.LoadParameters(2);
        SuperBubbles.LoadParameters(superBubblesPositions);
        EditPositions(superBubblesPositions);
        superBubblesCount = superBubblesPositions.Count;

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
        else if(timer > time){
            DestroyAllBubbles();
            CreateSuperBubbles();
        }

        if(superBubblesCount == 0){
            resultsMenu.SetActive(true);
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
            Vector3 spawnPos = new Vector3(Random.Range(xCenter - radius, xCenter + radius), 
                                            Random.Range(yCenter - radius < 0 ? 0 : yCenter - radius, yCenter + radius), 1);
            if(usedPositions.Contains(spawnPos))
                continue;
            Instantiate(spheres[index], spawnPos, spheres[index].transform.rotation);
            usedPositions.Add(spawnPos);
        }
    }

    void CreateSuperBubbles(){
        for(int i = 0; i < superBubblesPositions.Count; i++){
            Instantiate(superBubble, superBubblesPositions[i], superBubble.transform.rotation);
        }
    }

    void EditPositions(List<Vector3> positions){
        for(int i = 0; i < positions.Count; i++){
            positions[i] = new Vector3(positions[i].x, positions[i].y, 1);
        }
    }

    void DestroyAllBubbles(){
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        foreach(GameObject bubble in bubbles)
            Destroy(bubble);
    }
}
