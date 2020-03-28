using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject agent;
    public GameObject food;
    public GameObject cleraLabelObject;
    public UnityEngine.UI.Text dis;
    // Start is called before the first frame update
    void Start()
    {
        cleraLabelObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (food != null){
            Vector3 Agentpos = agent.transform.position;
            Vector3 Foodpos = food.transform.position;
            float dist = Vector3.Distance(Agentpos, Foodpos);
            dis.text = "Distance : " + dist;
        }else{
            cleraLabelObject.SetActive (true);
        }
        
    }
}
