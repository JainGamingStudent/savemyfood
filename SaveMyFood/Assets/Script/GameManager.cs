using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ant;
    public GameObject food;
    Vector3 genpos = Vector3.zero;
    public GameObject over;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sponeenemy());
    }

    IEnumerator sponeenemy()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(05f, 1.5f));
        GameObject obj = Instantiate(ant) as GameObject;
        if(Random.Range(0,10)>5)
        {
            genpos = new Vector3(Random.Range(-8.1f, 8.1f), -6, 0);
        }
        else
        {
            if (Random.Range(0, 10) > 5)
            {
                genpos = new Vector3(-8, Random.Range(-2.1f,-6.1f), 0);
            }
            else
            {
                genpos = new Vector3(8, Random.Range(-2.1f, -6.1f), 0);
            }
        }
        obj.transform.position = genpos;
        obj.GetComponent<enemyMovement>().destination = food.transform.position;
        obj.GetComponent<enemyMovement>()._manager = this;
        StartCoroutine(sponeenemy());
    }

    public void gameover()
    {
        over.SetActive(true);
        Time.timeScale = 0;
    }
    public void restartgame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
