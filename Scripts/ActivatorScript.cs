using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour {

    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject note, gm;
    Color old;
    public bool createMode;
    public GameObject n;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
        old = sr.color;
        gm = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {

        if (createMode)
        {
            if(Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }

            if (Input.GetKeyDown(key) && active)
            {
                
                Destroy(note);
                gm.GetComponent<GameManager>().addStreak();
                addScore();
                active = false;
            }
            else if(Input.GetKeyDown(key)&& !active)
            {
                gm.GetComponent<GameManager>().resetStreak();
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WinNote")
        {
            gm.GetComponent<GameManager>().Win();
            note = col.gameObject;
        }

        if (col.gameObject.tag == "Note")
        {
            active = true;
            note = col.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //Debug.Log("OnTriggerExit2d");
        active = false;
        //gm.GetComponent<GameManager>().resetStreak();
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.03f);
        sr.color = old;
    }

    void addScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+gm.GetComponent<GameManager>().getScore());
    }
}
