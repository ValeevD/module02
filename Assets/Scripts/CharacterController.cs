using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Character curCharacter;

    private void Start()
    {
        curCharacter = GetComponentInChildren<Character>();
    }

    public Character CurrentCharacter{
        get{
            return curCharacter;
        }
        set{
            if(curCharacter == null)
                curCharacter = value;
        }
    }

    public void MoveLeft()
    {
        curCharacter.MoveLeft();
    }

    public void MoveRight()
    {
        curCharacter.MoveRight();
    }

    public void Jump()
    {
        curCharacter.Jump();
    }
}
