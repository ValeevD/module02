using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public Character characterPrefab;

    private Transform _transform;
    private Character curCharacter;

    private void Awake()
    {
        _transform = transform;
        curCharacter = Instantiate(characterPrefab, _transform);
    }
}
