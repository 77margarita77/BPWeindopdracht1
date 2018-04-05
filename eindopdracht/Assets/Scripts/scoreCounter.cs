using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreCounter : MonoBehaviour {
    private int count;
    private int high;
    public Text countText;
    public Text highScore;

    void Start()
    {
        count = 0;
        SetCountText();
        SetHighText();
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", high).ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("i hit");
        if (other.tag == ("scoreObject"))
        {
            count = count + 1;
            Debug.Log(count);
            SetCountText();
            if (count > high)
            {
                high = count;
            }

            if (count > PlayerPrefs.GetInt("HighScore", high))
            {
                PlayerPrefs.SetInt("Highscore", high);
                highScore.text = "Highscore: " + high.ToString();
            }
            
        }

        else if (other.tag == ("scoreObjectHigh"))
        {
            count = count + 5;
            Debug.Log(count);
            SetCountText();

            if (count > high)
            {
                high = count;
            }

            if (count > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("Highscore", high);
                highScore.text = "Highscore: " + high.ToString();
            }

        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetHighText()
    {
        highScore.text = "Highscore: " + high.ToString();
    }
}
