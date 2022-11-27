using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{



    public void ProcessMove(Vector2 input)
    {
        Vector2 move = new Vector2(input.x, input.y);
        Debug.Log(input.x + input.y);
    }
}
