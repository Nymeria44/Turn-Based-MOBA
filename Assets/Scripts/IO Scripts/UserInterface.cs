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

    // Update is called once per frame
    public void ChangeTurnText (int turn)
    {
        if(turn == 1)
        {
            turnText.text = "Currently player one's turn";
        }

        if (turn == 2)
        {
            turnText.text = "Currently player two's turn";
        }

        turnText.text = TurnTracker.playerTurnText.text;
    }
}
