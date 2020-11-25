using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovingSystem : MonoBehaviour
{
    public GameObject currentPos;
    public Text score, hiscore;
    private bool moving;
    float startPosx, startPosy;
    Vector3 resetPos;


    void Start()
    {
        resetPos = this.transform.localPosition;
        score.text = PlayerPrefs.GetInt("Score").ToString();
        hiscore.text = "High Score: " + PlayerPrefs.GetInt("HiScore").ToString();

    }

    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosx, mousePos.y - startPosy, this.gameObject.transform.localPosition.z);
        }

    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosx = mousePos.x - this.transform.localPosition.x;
            startPosy = mousePos.y - this.transform.localPosition.y;
            moving = true;
        }
    }
    private void OnMouseUp()
    {
        moving = false;
        if (currentPos.GetComponent<SpriteRenderer>().sprite.name == gameObject.GetComponent<SpriteRenderer>().sprite.name)
        {
            if (Mathf.Abs(this.transform.localPosition.x - currentPos.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - currentPos.transform.localPosition.y) <= 0.5f)
            {
                this.transform.position = new Vector3(currentPos.transform.position.x, currentPos.transform.position.y, currentPos.transform.position.z);

                if (!PlayerPrefs.HasKey("Score"))
                    PlayerPrefs.SetInt("Score", 0);
                else
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);

                if (PlayerPrefs.GetInt("HiScore") < PlayerPrefs.GetInt("Score"))
                {
                    PlayerPrefs.SetInt("HiScore", PlayerPrefs.GetInt("Score"));
                }
                StartCoroutine(LoadAfter(1.0f));
            }
            else
                this.transform.localPosition = new Vector3(resetPos.x, resetPos.y, resetPos.z);
        }
        else
            this.transform.localPosition = new Vector3(resetPos.x, resetPos.y, resetPos.z);
    }

    IEnumerator LoadAfter(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("main");
    }
}
