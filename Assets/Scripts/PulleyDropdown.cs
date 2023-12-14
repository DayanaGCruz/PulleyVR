using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PulleyDropdown : MonoBehaviour
{
    public GameObject[] pulleys;
    public GameObject currentPulley;
    public TMP_Dropdown dropdown;
    private List<List<Vector3>> pulleyPositions = new List<List<Vector3>>();
    private bool isPaused = false;
    private string scene = "PulleyVR";
    //public List<Vector3> currPos = new List<Vector3>();
    //private string[] componentNames = { "Pulley", "Weight1", "Weight2" };
    //public Transform[] components;
    void Start()
    {
        //components = new Transform[componentNames.Length];
        /*
        for (int i = 0; i < pulleys.Length; i++)
        {
            pulleys[i].SetActive(true);
            currPos.Add(pulleys[i].transform.position);
            Debug.Log(i);
            Debug.Log(currPos[i].ToString());
            for (int j = 0; j < components.Length; j++) { 
                components[j] = pulleys[i].transform.Find(componentNames[j]); 
                currPos.Add(components[j].position); 
            }
            pulleyPositions.Add(currPos);
            pulleys[i].SetActive(false);
            Debug.Log("exited start");
        } */
        // Retrieve and set dropdown value
        int savedDropdownIndex = PlayerPrefs.GetInt("DropdownIndex", 0);
        dropdown.value = savedDropdownIndex;
        OnDropdownValueChanged(savedDropdownIndex); // Apply the saved dropdown value

        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    public void OnDropdownValueChanged(int index)
    {
        Debug.Log("Selected option: " + dropdown.options[index].text);
        Physics.gravity = new Vector3(0f, -9.81f, 0f); // Reset gravity to default
        // Handle the selected item based on the index
        if (index == 0) { ClearPulley(index); }
        else { ClearPulley(index); currentPulley = (pulleys[index - 1]); currentPulley.SetActive(true); };
    }
    void ClearPulley(int index)
    {
        if (currentPulley != null)
        {
            Debug.Log(index.ToString());
            //if (index != 0)
            //{
            /*
                Debug.Log(pulleyPositions[index-1][0].ToString());
                currentPulley.transform.position = pulleyPositions[index - 1][0];
                for (int j = 0; j < components.Length; j++)
                {
                    components[j] = currentPulley.transform.Find(componentNames[j]);
                    components[j].position = pulleyPositions[index - 1][j];
                }*/
                currentPulley.SetActive(false);

            //}
            
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        // If the game is paused, set timeScale to 0 (freezing time)
        // If the game is resumed, set timeScale back to 1 (normal time flow)
        Time.timeScale = isPaused ? 0f : 1f;
    }
    public void LoadScene()
    {
        // Save dropdown index and current pulley state before loading the scene
        PlayerPrefs.SetInt("DropdownIndex", dropdown.value);

        if (currentPulley != null)
        {
            PlayerPrefs.SetInt("CurrentPulleyActive", currentPulley.activeSelf ? 1 : 0);
            PlayerPrefs.SetFloat("CurrentPulleyPosX", currentPulley.transform.position.x);
            PlayerPrefs.SetFloat("CurrentPulleyPosY", currentPulley.transform.position.y);
            PlayerPrefs.SetFloat("CurrentPulleyPosZ", currentPulley.transform.position.z);
            // Add similar lines for other properties of the current pulley if needed
        }

        PlayerPrefs.Save();
        Physics.gravity = new Vector3(0f, -9.81f, 0f); // Reset gravity to default
        //int pulley = dropdown.value;
        SceneManager.LoadScene(scene);
        //OnDropdownValueChanged(pulley);
    }
    void OnApplicationQuit()
    {
        // Clear PlayerPrefs when the application is closed
        PlayerPrefs.DeleteAll();
    }
}
    