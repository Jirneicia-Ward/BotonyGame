using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private AudioSource accept;


    // Start is called before the first frame update
    void Start()
    {
        accept = GameObject.Find("Effects").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string Scene)
    {
        string[] sceneParts = Scene.Split('_');

        print(sceneParts[1]);
        if(sceneParts[1].Equals("Forwards"))
        {
            accept.GetComponent<BGEffectScript>().playForwards();
        }
        else
        {
            accept.GetComponent<BGEffectScript>().playBackwards();
        }

        SceneManager.LoadScene(int.Parse(sceneParts[0]));
    }
  
    public void QuitGame()
    {
        Application.Quit();
    }
}
