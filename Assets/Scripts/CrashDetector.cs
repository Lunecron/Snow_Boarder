using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.5f;
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    int currentSceneIndex;    

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControlles();
            deathEffect.Play();
            Invoke("ReloadScene", reloadDelay);
            GetComponent<AudioSource>().PlayOneShot(crashSFX);

        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
