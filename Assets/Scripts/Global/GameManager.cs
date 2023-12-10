using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform Player { get; set; }
    [SerializeField] private string playerTag = "Player";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }


}
