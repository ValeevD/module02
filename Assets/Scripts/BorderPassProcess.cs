using System.Collections.Generic;
using UnityEngine;

public class BorderPassProcess : MonoBehaviour
{
    public MenuController menuController;

    private Dictionary<Collider2D, Character> characterDict;

    private void Start()
    {
        characterDict = new Dictionary<Collider2D, Character>();

        var allCharacters = FindObjectsOfType<Character>();

        for(int i = 0; i < allCharacters.Length; ++i)
        {
            var allBoxes = allCharacters[i].GetComponentsInChildren<Collider2D>();

            for(int j = 0; j < allBoxes.Length; ++j)
            {
                if(allBoxes[j].isTrigger)
                    continue;

                characterDict.Add(allBoxes[j], allCharacters[i]);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!characterDict.ContainsKey(other))
            return;

        characterDict[other].SetDead();
        menuController.SetGameOver();
    }
}
