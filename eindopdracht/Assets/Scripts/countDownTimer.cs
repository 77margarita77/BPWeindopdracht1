using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countDownTimer : MonoBehaviour {
    public string levelToLoad;
    private float timer = 200f;
    private Text timerSeconds;

	// Use this for initialization
	void Start () {
        timerSeconds = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("f0");
        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
