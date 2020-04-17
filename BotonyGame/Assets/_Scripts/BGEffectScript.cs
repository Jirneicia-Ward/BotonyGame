using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGEffectScript : MonoBehaviour
{
    public AudioClip forwards;
    public AudioClip backwards;

    private static BGEffectScript instance = null;
    public static BGEffectScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void playForwards()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(forwards, .7f);
    }
    public void playBackwards()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(backwards, 1f);
    }
}