using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnTracker : MonoBehaviour
{
    public int playerTurn;
    public static TextMeshProUGUI playerTurnText;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = 1;
        UserInterface.Instance.ChangeTurnText(playerTurn);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerTurn == 1)
            {
                playerTurn = 2;
                UserInterface.Instance.ChangeTurnText(playerTurn);
            }
            
            if (playerTurn == 2)
            {
                playerTurn = 1;
                UserInterface.Instance.ChangeTurnText(playerTurn);
            }
        }
    }
}
