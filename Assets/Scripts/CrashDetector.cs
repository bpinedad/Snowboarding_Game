using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 3f;
    [SerializeField] ParticleSystem dieEffect;
    [SerializeField] ParticleSystem snowEffect;
    [SerializeField] AudioClip crashAudio;
    public bool isAlive = true;
    int level = 0;

    void OnTriggerEnter2D (Collider2D other){
        if (other.tag == "Ground" && isAlive){
            isAlive = false;
            dieEffect.Play();
            snowEffect.Stop();
            other.GetComponent<SurfaceEffector2D>().speed = 1;
            GetComponent<AudioSource>().PlayOneShot(crashAudio);
            Invoke("ReloadLevel", reloadDelay);
            Debug.Log("YouDied");
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
        SceneManager.LoadScene(level);
    }
}
