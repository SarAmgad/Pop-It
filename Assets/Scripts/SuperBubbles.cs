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
    public GameObject superBubble;
    private InputData _inputData;

    public static List<Vector3> positions = new List<Vector3>();

    private bool isMenuOpen = false;

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
                positions.Add(TriggerInputDetector.rControllerPos);
                Instantiate(superBubble, TriggerInputDetector.rControllerPos, superBubble.transform.rotation);
            }
            else if (TriggerInputDetector.lTriggerClicked)
            {
                positions.Add(TriggerInputDetector.lControllerPos);
                Instantiate(superBubble, TriggerInputDetector.lControllerPos, superBubble.transform.rotation);
            }
        }

        if(TriggerInputDetector.rGripClicked || TriggerInputDetector.lGripClicked){
            menu.SetActive(true);
            isMenuOpen = true;
        }
    }

    [Serializable]
    class SaveData
    {
        public List<Vector3> Positions;
    }

    public void SaveParameters(){
        SaveData data = new SaveData
        {
            Positions = positions
        };

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/positions.json", json);
    }

    public static void LoadParameters(List<Vector3> positions)
    {
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
