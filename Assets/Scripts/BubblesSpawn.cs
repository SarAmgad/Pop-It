using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesSpawn : MonoBehaviour
{

    public GameObject[] spheres;
    public GameObject superBubble, offset, resultsMenu, startingMenu, menu;
    public static float radius, time; 
    public static int badRatio;  
    public static int superBubblesCount;
    private float yCenter, zCenter, xCenter;
    private float timer = 0;
    public static bool yDestroyed = false;
    public static bool rDestroyed = false;
    public static bool gameStart = false;
    public static bool pauseGame = false;
    private bool isTimerEnd = false;

    public static List<Vector3> usedPositions = new List<Vector3>();
    private List<Vector3> superBubblesPositions = new List<Vector3>();

    void Start()
    {
        ShowKeyboard.LoadParameters(2);
        superBubblesPositions = SuperBubbles.LoadParameters();
    }

    void Update()
    {
        if(gameStart){
            gameStart = false;
            startingMenu.SetActive(false);

            yCenter = offset.transform.position.y;
            xCenter = offset.transform.position.x;
            zCenter = offset.transform.position.z;

            EditPositions(superBubblesPositions);
            superBubblesCount = superBubblesPositions.Count;

            SpawnRandomBubbles(5 - badRatio, badRatio);
        }
        else if(TriggerInputDetector.rGripClicked || TriggerInputDetector.lGripClicked){
            menu.SetActive(true);
            pauseGame = true;
        }
        else{
            if(timer <= time && yDestroyed){
            SpawnRandomBubbles(1, 0);
            yDestroyed = false;
            }
            else if(timer <= time && rDestroyed){
                SpawnRandomBubbles(0, 1);
                rDestroyed = false;
            }
            else if(timer > time && !isTimerEnd){
                DestroyAllBubbles();
                CreateSuperBubbles();
                isTimerEnd = true;
            }

            if(superBubblesCount == 0 && isTimerEnd){
                resultsMenu.SetActive(true);
            }

            timer += Time.deltaTime;
        }
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
                                            Random.Range(yCenter - radius < 0 ? 0 : yCenter - radius, yCenter + radius), zCenter + 1);
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
            positions[i] = new Vector3(positions[i].x + xCenter, positions[i].y + yCenter, zCenter + 1);
            // Debug.Log("======" + positions[i]);
        }
    }

    void DestroyAllBubbles(){
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        foreach(GameObject bubble in bubbles)
            Destroy(bubble);
    }
}
