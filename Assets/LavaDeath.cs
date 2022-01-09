using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class LavaDeath : MonoBehaviour
{
    public string lavaTag = "Lava";
    public string monsterTag = "LavaMonster";
    public LavaUI overlay;
    public AudioSource screamSound;
    public float caughtDistance = 1.0f;

    private float deadTime;
    private bool dying = false;

    void Start()
    {

    }

    void Update()
    {
        if (dying && (Time.timeSinceLevelLoad - deadTime) > 3.0f)
        {
            SceneManager.LoadScene("EleanorGame");
        }
        else if (dying && (Time.timeSinceLevelLoad - deadTime) > 0.5f)
        {
            GetComponent<FirstPersonController>().enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == lavaTag)
        {
            overlay.ShowLavaUI(true);
            screamSound.Play();
            deadTime = Time.timeSinceLevelLoad;
            dying = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == monsterTag && Vector3.Distance(transform.position, other.gameObject.transform.position) < caughtDistance)
        {
            GetComponent<FirstPersonController>().outOfControl = true;
        }
    }
}
