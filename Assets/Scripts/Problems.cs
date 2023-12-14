using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Problems : MonoBehaviour
{
    public TMP_Text problem;
    public TMP_Text statusText;
    private int currentProblem = 0;
    public TMP_Dropdown problemDropdown;
    private string[] problems = { "Have the blue weight reach the table", "Have the pink weight reach the table", "Let the vertical velocity of the pink weight approximate", "Let the vertical velocity of the blue weight approximate", "Let the blue weight stop at the marked height ", "Let the vertical velocity of the pink weight approximate ", "Let the vertical velocity of  the blue weight approximate " };
    private CheckCollision collisionScript = null;
    private GameObject weight1Object = null;
    private GameObject weight2Object = null;
    private float minHeight = 0f;
    private float maxHeight = 0f;
    public TMP_Text heightText;
    public Transform tHeightCanvas;
    private int currentHeight = 0;
    public float targetHeight;
    public float targetVelocity;
    void Start()
    {
        minHeight = -1;
        maxHeight = 5;
        statusText.text = "Unsolved";
        statusText.color = Color.white;
        currentProblem = 0;
        problem.text = problems[currentProblem];

        var dropdownOptions = new List<string>();
        for (int i = 0; i < problems.Length; i++)
        {
            string[] words = problems[i].Split(' ');
            string option = $"{i + 1}. {string.Join(" ", words.Take(3))}";
            dropdownOptions.Add(option);
        }


        problemDropdown.ClearOptions();
        problemDropdown.AddOptions(dropdownOptions);
        problemDropdown.onValueChanged.AddListener(SetProblem);
    }
    public void SetProblem(int problemIndex)
    {
        currentProblem = problemIndex;
        problem.text = problems[currentProblem];
        if (currentProblem == 2 || currentProblem == 3) { SetTargetVelocity(true); }
        if (currentProblem == 4) { weight2Object = GameObject.FindWithTag("weight2"); SetTargetHeight(weight2Object); }
        if (currentProblem == 5 || currentProblem == 6) { SetTargetVelocity(false); }
        //else {// checkProblem();
          //  Debug.Log("clearing height text");
       // heightText = getHeightText();
            //heightText.text = "";
        //}
        statusText.color = Color.white;
        statusText.text = "Unsolved";
        
    }
    public void NextProblem()
    {
        currentProblem = (currentProblem + 1) % problems.Length;
        problemDropdown.value = currentProblem;
        SetProblem(currentProblem);
    }

    public void PreviousProblem()
    {
        currentProblem = (currentProblem - 1 + problems.Length) % problems.Length;
        problemDropdown.value = currentProblem;
        SetProblem(currentProblem);
    }
    public void checkProblem()
    {
        switch (currentProblem)
        {
            case 0:
                Debug.Log("Checking prob 0");
                weight2Object = GameObject.FindWithTag("weight2");
                CheckCollisionProblem(weight2Object);
                break;
            case 1:
                Debug.Log("Checking prob 0");
                weight1Object = GameObject.FindWithTag("weight1");
                CheckCollisionProblem(weight1Object);
                break;
            case 2:
                Debug.Log("Prob 3 logic here");
                weight1Object = GameObject.FindWithTag("weight1");
                SetTargetVelocity(true);
                CheckVelocityProblem(weight1Object);
                break;
            case 3:
                Debug.Log("Prob 3 logic here");
                weight2Object = GameObject.FindWithTag("weight2");
                SetTargetVelocity(true);
                CheckVelocityProblem(weight2Object);
                break;
            case 4:
                Debug.Log("Prob 4 logic here");
                weight2Object = GameObject.FindWithTag("weight2");
                CheckHeightProblem(weight2Object);
                break;
            case 5:
                Debug.Log("Prob 5 logic here");
                weight1Object = GameObject.FindWithTag("weight1");
                CheckVelocityProblem(weight1Object);
                break;
            case 6:
                Debug.Log("Prob 6 logic here");
                weight2Object = GameObject.FindWithTag("weight2");;
                CheckVelocityProblem(weight2Object);
                break;
            default:
                break;
        }
    }

    void CheckCollisionProblem(GameObject weight)
    {
        GameObject tableObject = GameObject.FindWithTag("tabletop");
        GameObject pulleyBaseObject = GameObject.FindWithTag("pulleybase");
        // Attach the script to the GameObject
        if (weight.GetComponent<CheckCollision>() == null)
        {
            Debug.Log("no component");
            collisionScript = weight.AddComponent<CheckCollision>();
            Debug.Log("added component");
        }
        if (collisionScript != null & (collisionScript.colliderTag == "tabletop" || collisionScript.colliderTag == "pulleybase"))
        {
            Debug.Log(collisionScript.colliderTag);
            Debug.Log("tags matchs");
            statusText.color = Color.green;
            statusText.text = "Solved!";
            Debug.Log("Collision with tabletop detected, problem solved!");
            Destroy(collisionScript);
        }
    }
    void CheckHeightProblem(GameObject weight)
    {
        
        // Check whether the weight is at the target height
        float currentHeight = weight.transform.localPosition.y;
        float threshold = 1f; // Adjust the threshold of acceptance

        Debug.Log(currentHeight);
        Debug.Log(targetHeight);  
        if (Mathf.Abs(currentHeight - targetHeight) <= threshold)
        {
            statusText.text = "Solved!";
            statusText.color = Color.green;
            heightText.text = "";
        }
        else
        {
            statusText.text = "Unsolved";
            statusText.color = Color.white;
        }
    }
   void CheckVelocityProblem(GameObject weight)
{
    float threshold = 0.1f;

    Rigidbody rb = weight.GetComponent<Rigidbody>();
    float velocityMagnitude = rb.velocity.y;

    // Check if each component of the velocity is within the specified range
    //bool velX = Mathf.Abs(rb.velocity.x - targetVelocity) <= threshold;
    bool velY = Mathf.Abs(rb.velocity.y - targetVelocity) <= threshold;
    //bool velZ = Mathf.Abs(rb.velocity.z - targetVelocity) <= threshold;

    if (velY)
    {
        statusText.text = "Solved!";
        statusText.color = Color.green;
    }
}

    void SetTargetHeight(GameObject weight)
    {
        /*
        GameObject canvas = GameObject.FindWithTag("TargetHeightCanvas");
        heightText = canvas.transform.GetComponentInChildren<TMP_Text>();
        targetHeight = Random.Range(minHeight, maxHeight);
        Debug.Log(minHeight.ToString());
        Debug.Log(maxHeight.ToString());
        Debug.Log(targetHeight.ToString());
        heightText.transform.position = new Vector3(heightText.transform.position.x, targetHeight, heightText.transform.position.z);
        heightText.text = $"Target Height: {targetHeight:F2}";
        */
        Debug.Log("entered set target height");
        heightText = getHeightText();

        targetHeight = Random.Range(minHeight, maxHeight);

        Debug.Log($"minHeight: {minHeight}, maxHeight: {maxHeight}, targetHeight: {targetHeight}");

        // Assuming heightText has RectTransform component
        RectTransform textRect = heightText.GetComponent<RectTransform>();

        // Update the y position of the TMP_Text
        textRect.anchoredPosition = new Vector2(textRect.anchoredPosition.x, targetHeight);

        heightText.text = $"Target Height: {targetHeight:F2}";
        Debug.Log(heightText.text);
        Debug.Log("SetTargetHeight completed");
    }
    void SetTargetVelocity(bool zero)
    {

        if (zero)
        {
            targetVelocity = 0;
            problem.text = $"{problems[currentProblem]} {targetVelocity:F2}";
        }
        else
        {
            targetVelocity = Random.Range(0.5f, 1.5f);
            problem.text = $"{problems[currentProblem]} {targetVelocity:F2}";
        }

    }
    public TMP_Text getHeightText()
    {
        Debug.Log("Getting heighttext");
        GameObject canvas = GameObject.FindWithTag("TargetHeightCanvas");

        if (canvas != null)
        {
            heightText = canvas.GetComponentInChildren<TMP_Text>();
            heightText.text = "Target Height : ?";
            return heightText;
        }
        else
        {
            Debug.LogError("Canvas not found.");
            return null;
        }
    }
}
