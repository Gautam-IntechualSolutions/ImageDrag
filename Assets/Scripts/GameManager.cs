using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    int a;

 
    // Start is called before the first frame update
    void Start()
    {

        ResetObj();

    }

    public void ResetObj()
    {
        a = Random.Range(1, 7);
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprite0" + a.ToString());
    }


}
