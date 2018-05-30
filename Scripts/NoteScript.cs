using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    bool called = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        rb.velocity = new Vector2(0, -speed);
        if (PlayerPrefs.GetInt("Start") == 1&&!called)
        {
            
            called = true;
        }
    }
}
