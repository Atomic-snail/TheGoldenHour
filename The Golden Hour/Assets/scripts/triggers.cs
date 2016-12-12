using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class triggers : MonoBehaviour {

    ambientSound AmbientSound;

    public float[] SectionLightLevels;

    //section particles
    public GameObject section1Particles;
    public GameObject section2Particles;
    public GameObject section3Particles;
    public GameObject section4Particles;
    public GameObject section5Particles;
    //secion particle lights
    public Light section1ParticleLight;
    public Light section2ParticleLight;
    public Light section3ParticleLight;
    public Light section4ParticleLight;
    public Light section5ParticleLight;
    //section skyboxes
    public Material section1Skybox;
    public Material section2Skybox;
    public Material section3Skybox;
    public Material section4Skybox;
    public Material section5Skybox;
    //section directional Lights
    public GameObject section1Light;
    public GameObject section2Light;
    public GameObject section3Light;
    public GameObject section4Light;
    public GameObject section5Light;
    //lighMaps
    public LightmapData section1LightMap;
    public LightmapData section2LightMap;
    public LightmapData section3LightMap;
    public LightmapData section4LightMap;
    public LightmapData section5LightMap;

    //curent section Enum
    enum section
    {
        start,
        one,
        two,
        three,
        four,
        five
    }
    section currentSection;

    // Use this for initialization
    void Start () {
        //find ambient sound
        AmbientSound = GameObject.FindGameObjectWithTag("Player").GetComponent<ambientSound>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //trigger after leaving beginning section
	    if(currentSection == section.one)
        {
            //fade light for particle glow
            if (section1Particles != null)
            {
                section1ParticleLight.intensity -= Time.deltaTime;
                if (section1ParticleLight.intensity <= 0)
                {
                    Destroy(section1Particles);
                }
            }
            //fade out beginning section light and fade in second section light
            if(section2Light.GetComponent<Light>().intensity < SectionLightLevels[1])
                section2Light.GetComponent<Light>().intensity += Time.deltaTime;
            else if(section2Light.GetComponent<Light>().intensity >= SectionLightLevels[1])
                section2Light.GetComponent<Light>().intensity = SectionLightLevels[1];
            if(section1Light.GetComponent<Light>().intensity != 0)
                section1Light.GetComponent<Light>().intensity -= Time.deltaTime;
            else
                section1Light.SetActive(false);
            
            
        }
        //triggered after leaving section 2
        if (currentSection == section.two)
        {
            //fade light for particles
            if (section2Particles != null)
            {
                section2ParticleLight.intensity -= Time.deltaTime;
                if (section2ParticleLight.intensity <= 0)
                {
                    Destroy(section2Particles);
                }
            }
            //fade out second section light and fade in third section light
            if (section3Light.GetComponent<Light>().intensity < SectionLightLevels[2])
                section3Light.GetComponent<Light>().intensity += Time.deltaTime;
            else if (section3Light.GetComponent<Light>().intensity >= SectionLightLevels[2])
                section3Light.GetComponent<Light>().intensity = SectionLightLevels[2];
            if (section2Light.GetComponent<Light>().intensity != 0)
                section2Light.GetComponent<Light>().intensity -= Time.deltaTime;
            else
                section1Light.SetActive(false);
        }
        //trigger after leaving section 3
        if (currentSection == section.three)
        {
            //fade light for particles
            if (section3Particles != null)
            {
                section3ParticleLight.intensity -= Time.deltaTime;
                if (section3ParticleLight.intensity <= 0)
                {
                    Destroy(section3Particles);
                }
            }
            //fade out third section light and fade in forth section light
            if (section4Light.GetComponent<Light>().intensity < SectionLightLevels[3])
                section4Light.GetComponent<Light>().intensity += Time.deltaTime;
            else if (section4Light.GetComponent<Light>().intensity >= SectionLightLevels[3])
                section4Light.GetComponent<Light>().intensity = SectionLightLevels[3];
            if (section3Light.GetComponent<Light>().intensity != 0)
                section3Light.GetComponent<Light>().intensity -= Time.deltaTime;
            else
                section1Light.SetActive(false);
        }
        //trigger after leaving section 4
        if (currentSection == section.four)
        {
            //fade light for particles
            if (section4Particles != null)
            {
                section4ParticleLight.intensity -= Time.deltaTime;
                if (section4ParticleLight.intensity <= 0)
                {
                    Destroy(section4Particles);
                }
            }
            //fade out forth section light and fade in fifth section light
            if (section5Light.GetComponent<Light>().intensity < SectionLightLevels[4])
                section5Light.GetComponent<Light>().intensity += Time.deltaTime;
            else if (section5Light.GetComponent<Light>().intensity >= SectionLightLevels[4])
                section5Light.GetComponent<Light>().intensity = SectionLightLevels[4];
            if (section4Light.GetComponent<Light>().intensity != 0)
                section4Light.GetComponent<Light>().intensity -= Time.deltaTime;
            else
                section1Light.SetActive(false);
        }
        //trigger upon arriving at the sunset
        if (currentSection == section.five)
        {
            //fade light for particles
            if (section5Particles != null)
            {
                section5ParticleLight.intensity -= Time.deltaTime;
                if (section5ParticleLight.intensity <= 0)
                    Destroy(section5Particles);
            }
        }
    }
    void OnTriggerExit(Collider otherObject)
    {
        //trigger after leaving beginning section
        if (otherObject.gameObject.tag == "section1")
        {
            //SceneManager.LoadScene("section2");
            //turn of particle emitter
            ParticleSystem system = section1Particles.GetComponent<ParticleSystem>();
            system.Stop();
            //prepare next section
            section2Particles.SetActive(true);
            //section1Light.SetActive(false);
            section2Light.SetActive(true);
            RenderSettings.skybox = section2Skybox;
            currentSection = section.one;
            AmbientSound.setNight();
        }
        //triggered after leaving section 2
        else if (otherObject.gameObject.tag == "section2")
        {
            //SceneManager.LoadScene("section3");
            ParticleSystem system = section2Particles.GetComponent<ParticleSystem>();
            system.Stop();
            section3Particles.SetActive(true);
            //section2Light.SetActive(false);
            section3Light.SetActive(true);
            RenderSettings.skybox = section3Skybox;
            currentSection = section.two;
            AmbientSound.setDay();
            section2Light.GetComponent<MeshRenderer>().enabled = false;
            section2Light.GetComponent<LensFlare>().enabled = false;
        }
        //trigger after leaving section 3
        else if (otherObject.gameObject.tag == "section3")
        {
            //SceneManager.LoadScene("section4");
            ParticleSystem system = section3Particles.GetComponent<ParticleSystem>();
            system.Stop();
            section4Particles.SetActive(true);
            //section3Light.SetActive(false);
            section4Light.SetActive(true);
            RenderSettings.skybox = section4Skybox;
            currentSection = section.three;
            AmbientSound.setNight();
        }
        //trigger after leaving section 4
        else if (otherObject.gameObject.tag == "section4")
        {
            //SceneManager.LoadScene("section5");
            ParticleSystem system = section4Particles.GetComponent<ParticleSystem>();
            system.Stop();
            section5Particles.SetActive(true);
            //section4Light.SetActive(false);
            section5Light.SetActive(true);
            RenderSettings.skybox = section5Skybox;
            currentSection = section.four;
            AmbientSound.setDay();
            section4Light.GetComponent<MeshRenderer>().enabled = false;
            section4Light.GetComponent<LensFlare>().enabled = false;
        }
        //trigger upon arriving at the sunset
        else if (otherObject.gameObject.tag == "section5")
        {
            ParticleSystem system = section5Particles.GetComponent<ParticleSystem>();
            system.Stop();
            currentSection = section.five;
        }        
        Destroy(otherObject.gameObject);
    }
}
