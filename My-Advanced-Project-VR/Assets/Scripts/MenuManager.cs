using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int sceneIndex;
    public Image BGMImage;
    public GameObject BGM;
    private float a;
    private void Awake()
    {
       if(PlayerPrefs.HasKey("isMusicOn")) 
        {
            if (PlayerPrefs.GetInt("isMusicOn") == 1)
            {
                a = 1f;
            }
            else
            {
                a = 0.5f;
            }
        }
        else
        {
            PlayerPrefs.SetInt("isMusicOn",1);
            a = 1f;
            PlayerPrefs.Save();
        }
    }
    private void OnEnable()
    {
        Cursor.visible = true;
    }
    private void OnDisable()
    {
        Cursor.visible = false;
    }
    public void TurnScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
        AudioManager._instance.Clik();
    }
    public void TurnSceneNewStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager._instance.Clik();
    }
    public void Conti()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        AudioManager._instance.Clik();
    }
    public void Music()
    {
        Debug.LogWarning("VR");
        if (PlayerPrefs.GetInt("isMusicOn")==1)
        {
            a = 0.5f;
            BGM.SetActive(false);
            PlayerPrefs.SetInt("isMusicOn", 0);
        }
        else
        {
            BGM.SetActive(true);
            a = 1f;
            PlayerPrefs.SetInt("isMusicOn", 1);
        }
        PlayerPrefs.Save();
        Color color = new Color(BGMImage.color.r, BGMImage.color.b, BGMImage.color.g,a);
        BGMImage.color = color;
        AudioManager._instance.Clik();
    }
}
