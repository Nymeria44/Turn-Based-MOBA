using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    // Singleton pattern for avoiding static thorwing a shit fit
    public static UserInterface Instance { get; private set; }
    [SerializeField] 
    private TextMeshProUGUI turnText;
    
    // Awake is called before the start
    void Awake()
    {
        if (Instance != null)
        {
            throw new System.Exception("An instance of user interface already exists");
        }
        Instance = this;
    }

    /// <summary>
    /// Used to display which teams turn it is on the UI
    /// </summary>
    /// <param name="turn"></param>
    public void ChangeTurnText (int turn)
    {
        if(turn == 1)
        {
            turnText.text = "Currently player one's turn";
        }

        else if (turn == 2)
        {
            turnText.text = "Currently player two's turn";
        }
        else
        {
            Debug.Log("This is what is causing the issue");
        }
    }
}
