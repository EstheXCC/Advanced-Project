using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	Ray ray;
	RaycastHit hit;
	public float attackValue;
    private void OnEnable()
    {
        StartCoroutine("wait");
    }
	[SerializeField]
	public float[] volume;
	public float realVolume;
	private AudioClip[] micRecord;
	public string[] Devices;
	private void Awake()
	{
		attackValue = 1;
		   Devices = Microphone.devices;
		if (Devices.Length > 0)
		{
			micRecord = new AudioClip[Devices.Length];
			volume = new float[Devices.Length];
			for (int i = 0; i < Devices.Length; i++)
			{
				if (Microphone.devices[i].IsNormalized())
				{
					micRecord[i] = Microphone.Start(Devices[i], true, 999, 44100);
				}
			}
		}
		else
		{
			Debug.LogError("找不到麦克风");
		}
	}
	void Update()
	{
		ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f));
		//Debug.DrawRay(ray.origin,ray.direction);
		realVolume = Mathf.Clamp01(realVolume);
		if (Devices.Length > 0)
		{
			for (int i = 0; i < Devices.Length; i++)
			{
				volume[i] = GetMaxVolume(i);
				if (volume[i] != 0)
				{
					realVolume = volume[i];
				}
			}
		}
		if (Physics.Raycast(ray, out hit, 2,LayerMask.GetMask("Enemy")))
		{
            if (hit.collider.tag=="enemy")
            {
				//Debug.Log("s");
                if (realVolume>0.1f)
                {
					hit.collider.gameObject.GetComponent<Enemy>().t = 1f;
					hit.collider.gameObject.GetComponent<Enemy>().Anim.SetBool("hit", true);
					hit.collider.gameObject.GetComponent<Enemy>().isHit = true;
					hit.collider.gameObject.GetComponent<Enemy>().tHit = hit.collider.gameObject.GetComponent<Enemy>().TimerHit;
					hit.collider.gameObject.GetComponent<Enemy>().health -= realVolume * attackValue;
					
				}
               
				
            }
			
		}
	}

	
	float GetMaxVolume(int x)
	{
		float maxVolume = 0f;
		
		float[] volumeData = new float[128];
		int offset = Microphone.GetPosition(Devices[x]) - 128 + 1;
		if (offset < 0)
		{
			return 0;
		}
		micRecord[x].GetData(volumeData, offset);

		for (int i = 0; i < 128; i++)
		{
			float tempMax = volumeData[i];
			if (maxVolume < tempMax)
			{
				maxVolume = tempMax;
			}
		}
		return maxVolume;
	}

   
    private   IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
