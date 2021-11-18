using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("U Finished");
            Invoke("ReloadScene", reloadDelay);
        }
       
    }


    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
