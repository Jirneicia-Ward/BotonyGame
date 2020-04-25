using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGEffectScript : MonoBehaviour
{
    public AudioClip forwards;
    public AudioClip backwards;
    public AudioClip success;
    public AudioClip click;
    public AudioClip slotDrop;
    public AudioClip trash;

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
    public void playSuccess()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(success, 1f);
    }
    public void playClick()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(click, 1f);
    }
    public void playSlotDrop()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(slotDrop, 1f);
    }
    public void playTrash()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(trash, 1f);
    }
}