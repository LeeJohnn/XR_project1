using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class subtitles : MonoBehaviour
{
    public GameObject cam;
    public SteamVR_LaserPointer laserPointer;
    private float distance = 1.5f; // distance from user
    private bool clickobject = false;
    private float timeRemaining;
    private float timeout = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        laserPointer.PointerClick += PointerClick;
    }
    void Start()
    {
        if(gameObject.activeInHierarchy)
            gameObject.SetActive(false);
        timeRemaining = timeout;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if(e.target.tag == "Interactable") {
            clickobject = true;
            gameObject.SetActive(true);
            if(e.target.name == "PFB_Fridge")
                transform.GetChild(0).GetComponent<TextMesh>().text = "該睡覺了，不能再吃了";
            else if(e.target.name == "PFB_Basket")
                transform.GetChild(0).GetComponent<TextMesh>().text = "臭死了，昨天的便當味";
            else if(e.target.name.Substring(0, 9) == "Garlic_01")
                transform.GetChild(0).GetComponent<TextMesh>().text = "聽說大蒜可以驅邪";
            else if(e.target.name.Substring(0, 13) == "Satellite_low")
                transform.GetChild(0).GetComponent<TextMesh>().text = "我最愛聽抖音歌";
            // else if(e.target.name == "mug")
            //     transform.GetChild(0).GetComponent<TextMesh>().text = "再喝水等等又要尿尿了";
            else if(e.target.name == "PFB_DiningChair")
                transform.GetChild(0).GetComponent<TextMesh>().text = "作業還沒寫完，算了先睡覺";   
        } else if(e.target.tag == "Interactable_bed"){
            clickobject = true;
            gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<TextMesh>().text = "真是煩，趕快來睡覺";
        } else if(e.target.tag == "Interactable_light") {
            clickobject = true;
            gameObject.SetActive(true);
            if(e.target.GetChild(0).GetChild(0).GetComponent<Light>().enabled)
                transform.GetChild(0).GetComponent<TextMesh>().text = "關燈";
            else 
                transform.GetChild(0).GetComponent<TextMesh>().text = "開燈";
        }
    }
    // Update is called once per frame
    void Update()
    {
        // reset timeRemaining
        if(clickobject) {
            timeRemaining = timeout;
            clickobject = false;
        }
        if(gameObject.activeInHierarchy && timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        } else {
            gameObject.SetActive(false);
        }
        // move subtitle in front of user
        transform.position = cam.transform.position + cam.transform.forward * distance;
        transform.Translate(0, -0.5f, 0);
        // let subtitle face user
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
        
        

    }
}
