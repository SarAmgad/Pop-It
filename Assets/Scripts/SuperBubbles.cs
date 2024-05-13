using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SuperBubbles : MonoBehaviour
{
    public GameObject menu;
    public static GameObject superBubble;
    private InputData _inputData;

    public static List<Vector3> positions = new List<Vector3>();

    public static bool isMenuOpen = false;

    public static bool therapistScene = false;

    // Start is called before the first frame update
    void Start()
    {
        therapistScene = true;
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMenuOpen){
            if (TriggerInputDetector.rTriggerClicked)
            {
                // Debug.Log(TriggerInputDetector.rControllerPos);
                // positions.Add(TriggerInputDetector.rControllerPos);
                // Instantiate(superBubble, TriggerInputDetector.rControllerPos, superBubble.transform.rotation);
            }
            else if (TriggerInputDetector.lTriggerClicked)
            {
                // positions.Add(TriggerInputDetector.lControllerPos);
                // Instantiate(superBubble, TriggerInputDetector.lControllerPos, superBubble.transform.rotation);
            }
        }

        if(TriggerInputDetector.rGripClicked || TriggerInputDetector.lGripClicked){
            // Debug.Log("2nd condition");
            menu.SetActive(true);
            isMenuOpen = true;
        }
    }

    public static void SuperBubbleInstaniate(Vector3 pos){
        positions.Add(pos);
        Instantiate(superBubble, pos, superBubble.transform.rotation);
    }

    [Serializable]
    class SaveData
    {
        public List<Vector3> Positions;
    }

    public void SaveParameters(){
        Debug.Log("Save Parameters Superrrr");
        SaveData data = new SaveData
        {
            Positions = positions
        };

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/positions.json", json);
    }

    public static void LoadParameters(List<Vector3> positions)
    {
        Debug.Log("Load Parameters Superrrr");
        string path = Application.persistentDataPath + "/positions.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            positions = data.Positions;
        }
    }

    public void CloseMenu(){
        menu.SetActive(false);
        isMenuOpen = false;
    }

    public void Done(){
        SaveParameters();
        SceneManager.LoadScene(0);
    }

}
