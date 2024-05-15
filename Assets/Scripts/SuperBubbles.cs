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
        // isMenuOpen = false;
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public static List<Vector3> LoadParameters()
    {
        string path = Application.persistentDataPath + "/positions.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data.Positions;
        }
        return new List<Vector3>();
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
