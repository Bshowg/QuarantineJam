using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeerPressure : MonoBehaviour{
    public float radius;

    public float peopleNoise;
    public float minNumberOfPeopleToHearNoise;
    public float noiseWithoutPeople;

    public float cameraMovementSpeed;
    public float cameraReductionRatio;
    public int peopleToTriggerCamera;

    public float breathChangeSpeed;

    private TextManager textmanager = null;
    private int crowdLayer = 0;

    private bool continueChecking = true;

    private AudioSource gibberish;

    private float camsize;
    private float desiredSize;

    private Camera cam;

    private AudioSource breath;
    private float desiredAudioIntensity;
    
    
    private IEnumerator checkForPeopleAround() {
        while (continueChecking) {
            Collider2D[] cs = Physics2D.OverlapCircleAll(transform.position, radius, crowdLayer);
            //requireTexts(cs.Length);
            List<GameObject> gs = new List<GameObject>();
            foreach(Collider2D c in cs) { 
                gs.Add(c.gameObject); 
            }
            textmanager.requireTexts(gs);

            float noiseintensity = ((float)(Mathf.Max(cs.Length - minNumberOfPeopleToHearNoise, 0)) * peopleNoise) + noiseWithoutPeople;
            gibberish.volume = Mathf.Min(1f, noiseintensity);

            desiredSize = (cs.Length >= peopleToTriggerCamera) ? camsize * cameraReductionRatio : camsize;
        
            yield return new WaitForSeconds(.5f);
        }
    }

    private void requireTexts(int howMany) {
        Debug.Log("Required " + howMany + " texts");
    }

    void Start(){
        crowdLayer = 1 << LayerMask.NameToLayer("Crowd");
        textmanager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
        cam = Camera.main;
        camsize = cam.orthographicSize;
        desiredSize = cam.orthographicSize;
        gibberish = gameObject.GetComponents<AudioSource>()[0];
        breath = gameObject.GetComponents<AudioSource>()[1];
        gibberish.volume = 0f;
        StartCoroutine(checkForPeopleAround());
    }

    // Update is called once per frame
    void Update(){
        if (desiredSize < cam.orthographicSize)
        {
            cam.orthographicSize = Mathf.Max(desiredSize, cam.orthographicSize - (cameraMovementSpeed * Time.deltaTime));
        }
        else if (desiredSize > cam.orthographicSize)
        {
            cam.orthographicSize = Mathf.Min(camsize, cam.orthographicSize + (cameraMovementSpeed * Time.deltaTime));
        }
        if (desiredAudioIntensity < breath.volume)
        {
            breath.volume = Mathf.Max(0, breath.volume - (breathChangeSpeed * Time.deltaTime));
        }
        else if (desiredAudioIntensity > breath.volume)
        {
            breath.volume = Mathf.Min(1, breath.volume + (breathChangeSpeed * Time.deltaTime));
        }
    }
}
