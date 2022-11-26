
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject FBX;
    public bool isFbx=false;
    CharacterController playerController;

    Vector3 direction;

    public float speed = 1;
    public float jumpPower = 5;
    public float gravity = 7f;

    public float mousespeed = 5f;


    public float minmouseY = -45f;
    public float maxmouseY = 45f;

    float RotationY = 0f;
    float RotationX = 0f;

    public Transform agretctCamera;
    public GameObject hurt;
    public float a;
    public int Health;
   // public Text healthT;
    public static Character _instance;
    private AudioSource AudioS;
    bool isAudioPlay=false;
    public RectTransform HealthImage;
    public GameObject Set;

    IEnumerator WAIT()
    {
        yield return new WaitForSeconds(2f);
        FBX.gameObject.SetActive(false);
       
    }
    // Use this for initialization
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        Health = 100;
        Cursor.visible = false;
        AudioS = GetComponent<AudioSource>();
        playerController = this.GetComponent<CharacterController>();
        Health = Mathf.Clamp(Health,0,100);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFbx)
        {
            FBX.SetActive(true);
            StartCoroutine("WAIT");
            isFbx = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&&GameManager._instance.isKeyEsc)
        {
            Set.SetActive(true);
            Time.timeScale = 0f;
        }
     
           
            HealthImage.sizeDelta = new Vector2(600f*(Health/100f),HealthImage.sizeDelta.y);
         
       // healthT.text = Health.ToString();
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        if ((_horizontal!=0|| _vertical!=0)&&isAudioPlay==false)
        {
            AudioS.Play();
            isAudioPlay = true;
        }
        if (_horizontal == 0 && _vertical == 0 && isAudioPlay == true)
        {
            AudioS.Pause();
            isAudioPlay = false;
        }
        if (playerController.isGrounded)
        {
            direction = new Vector3(_horizontal, 0, _vertical);
            if (Input.GetKeyDown(KeyCode.Space))
                direction.y = jumpPower;
        }
        direction.y -= gravity * Time.deltaTime;
        playerController.Move(playerController.transform.TransformDirection(direction * Time.deltaTime * speed));

        RotationX += agretctCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousespeed;

        RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);

        this.transform.eulerAngles = new Vector3(0, RotationX, 0);

        agretctCamera.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);
        Hurt();
        Physics.SyncTransforms();
    }
    public void Hurt()
    {
        a = Mathf.Clamp01(a);
        a -= Time.deltaTime * 0.5f;
        Color color = new Color(hurt.GetComponent<Image>().color.r, hurt.GetComponent<Image>().color.g, hurt.GetComponent<Image>().color.b, a);
        hurt.GetComponent<Image>().color = color;
    }
    
}

