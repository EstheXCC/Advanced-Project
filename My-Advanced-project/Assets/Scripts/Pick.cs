using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pick : MonoBehaviour
{
    
    public string powerIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.GetComponent<Character>().isFbx = true;
            AudioManager._instance.Pick();
            PowerManager[] gameObjects = FindObjectsOfType<PowerManager>();
            for (int i=0;i<gameObjects.Length;i++)
            {
                if (gameObjects[i].gameObject.name== string.Format("{0}", powerIndex))
                {
                    Color a = new Color(gameObjects[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, gameObjects[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, gameObjects[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.b,1);
                    gameObjects[i].gameObject.transform.GetChild(0).GetComponent<Image>().color = a;
                    transform.parent.GetComponent<PowerPoint>().Spawn();
                    Destroy(gameObject);
                }
            }
        }
    }
   
}
