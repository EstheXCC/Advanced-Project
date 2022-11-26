using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    public GameObject Bubble;
    public GameObject bubbleIcon;
    public GameObject attackIcon;
    public GameObject petIcon;
    public GameObject pet;
    public GameObject Player; 
    public GameObject brainIcon;
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (transform.GetChild(0).GetComponent<Image>().color.a == 1)
            {
                if (gameObject.name=="1"&&bubbleIcon.active==false)
                {
                    Color a = new Color(transform.GetChild(0).GetComponent<Image>().color.r, transform.GetChild(0).GetComponent<Image>().color.g, transform.GetChild(0).GetComponent<Image>().color.b, 0.5f);
                   transform.GetChild(0).GetComponent<Image>().color = a;
                    Bubble.SetActive(true);
                    bubbleIcon.SetActive(true);
                    AudioManager._instance.UsePower();
                }
              else  if (gameObject.name == "2" && attackIcon.active == false)
                {
                    Color a = new Color(transform.GetChild(0).GetComponent<Image>().color.r, transform.GetChild(0).GetComponent<Image>().color.g, transform.GetChild(0).GetComponent<Image>().color.b, 0.5f);
                    transform.GetChild(0).GetComponent<Image>().color = a;                  
                    attackIcon.SetActive(true); 
                    AudioManager._instance.UsePower();
                }
                else if (gameObject.name == "3" && petIcon.active == false)
                {
                    Color a = new Color(transform.GetChild(0).GetComponent<Image>().color.r, transform.GetChild(0).GetComponent<Image>().color.g, transform.GetChild(0).GetComponent<Image>().color.b, 0.5f);
                    transform.GetChild(0).GetComponent<Image>().color = a;
                    petIcon.SetActive(true);
                    Instantiate(pet,Player.transform.localPosition-Vector3.forward*2,Quaternion.identity);
                    AudioManager._instance.UsePower();
                }
                else if (gameObject.name == "4" && brainIcon.active == false)
                {
                    Color a = new Color(transform.GetChild(0).GetComponent<Image>().color.r, transform.GetChild(0).GetComponent<Image>().color.g, transform.GetChild(0).GetComponent<Image>().color.b, 0.5f);
                    transform.GetChild(0).GetComponent<Image>().color = a;
                    brainIcon.SetActive(true);
                    Player.GetComponent<Character>().speed *= 1.5f;
                    AudioManager._instance.UsePower();
                }
            }
        }
       
    }
   
}
