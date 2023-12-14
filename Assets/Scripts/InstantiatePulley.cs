using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class InstantiatePulley : MonoBehaviour
{
    public GameObject[] pulleys;
    public GameObject currentPulley;
    public TMP_Dropdown dropdown;
    
    void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    public void OnDropdownValueChanged(int index)
    {
        Debug.Log("Selected option: " + dropdown.options[index].text);
        Physics.gravity = new Vector3(0f, -9.81f, 0f); // Reset gravity to default
        // Handle the selected item based on the index
        if (index == 0) { clearPulley();  }
        else { clearPulley(); currentPulley = Instantiate(pulleys[index - 1]); };
    }
    void clearPulley()
    {
        if (currentPulley != null)
        {
            Destroy(currentPulley);
        }
    }
    
}
