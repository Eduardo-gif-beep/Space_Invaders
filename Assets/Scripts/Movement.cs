using UnityEngine;
using System;


public class Movement : MonoBehaviour
{
    [SerializeField] int x = 0;
    [SerializeField] Transform y ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = x + 1; 
    }
}
