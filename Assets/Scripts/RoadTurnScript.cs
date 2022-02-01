using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTurnScript : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = new Sprite[4];
    public int turnKind;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[turnKind];
    }

    
    
}
