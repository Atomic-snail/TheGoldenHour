using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

    public AudioClip[] tracks;
    public AudioSource BGM;
    // Use this for initialization
    void Start()
    {
        int track = Random.RandomRange(0, tracks.Length);
        BGM.clip = tracks[track];
        BGM.Play();
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
