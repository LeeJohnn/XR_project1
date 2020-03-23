using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class Highlight : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    private Color startcolor;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
        //bound = new Bounds();
        
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PointerClick(object sender, PointerEventArgs e)
    {
        if(e.target.tag == "Interactable_light"){
            for(int i=0; i<e.target.childCount; i++)
                e.target.GetChild(i).GetChild(0).GetComponent<Light>().enabled = !e.target.GetChild(i).GetChild(0).GetComponent<Light>().enabled;
        }

    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if(e.target.tag == "Interactable" || e.target.tag == "Interactable_light")
            e.target.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
        else if(e.target.tag == "Interactable_bed") {
            for(int i=0; i<e.target.transform.parent.childCount; i++) {
                if(e.target.transform.parent.GetChild(i).tag == "Interactable_bed")
                    e.target.transform.parent.GetChild(i).GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
            }
        }

        
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if(e.target.tag == "Interactable" || e.target.tag == "Interactable_light")
            e.target.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        else if(e.target.tag == "Interactable_bed") {
            for(int i=0; i<e.target.transform.parent.childCount; i++) {
                if(e.target.transform.parent.GetChild(i).tag == "Interactable_bed")
                    e.target.transform.parent.GetChild(i).GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
