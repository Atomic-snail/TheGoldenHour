using UnityEngine;
using System.Collections;

public class ambientSound : MonoBehaviour {

    public AudioSource daySounds;
    public AudioSource nightSounds;
    public AudioClip toNight;
    public AudioClip toDay;

    enum time
    {
        day, 
        night
    }
    time TimeOfDay;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(TimeOfDay == time.day)
        {
            daySounds.volume += Time.deltaTime;
            nightSounds.volume -= Time.deltaTime;
        }
        if (TimeOfDay == time.night)
        {
            daySounds.volume -= Time.deltaTime;
            nightSounds.volume += Time.deltaTime;
        }
    }

    public void setDay()
    {
        TimeOfDay = time.day;
        daySounds.PlayOneShot(toDay);

    }
    public void setNight()
    {
        TimeOfDay = time.night;
        nightSounds.PlayOneShot(toNight);
    }
}
