using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 5f;
    [SerializeField] ParticleSystem finishEffect;
    SurfaceEffector2D surfaceEffector2D;
    int level = 0;

    void Start(){
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            finishEffect.Play();
            surfaceEffector2D.speed /= 2;
            GetComponent<AudioSource>().Play();
            Invoke("ReloadLevel", reloadDelay);
            
        }    
    }

    void ReloadLevel(){
        SceneManager.LoadScene(level);
    }
}
