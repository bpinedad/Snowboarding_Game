using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem dieEffect;
    [SerializeField] ParticleSystem snowEffect;
    bool isAlive = true;

    void OnTriggerEnter2D (Collider2D other){
        if (other.tag == "Ground"){
            isAlive = false;
            dieEffect.Play();
            snowEffect.Stop();
            other.GetComponent<SurfaceEffector2D>().speed = 1;
            Invoke("ReloadLevel", reloadDelay);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" && isAlive){
            snowEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground"){
            snowEffect.Stop();
        }
    }

    void ReloadLevel(){
        SceneManager.LoadScene(0);
    }
}
