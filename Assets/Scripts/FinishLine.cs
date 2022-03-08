using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    int level = 0;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            finishEffect.Play();
            level = 1;
            Invoke("ReloadLevel", reloadDelay);

        }    
    }

    void ReloadLevel(){
        SceneManager.LoadScene(level);
    }
}
