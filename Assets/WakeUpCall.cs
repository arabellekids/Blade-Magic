using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WakeUpCall : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Hello Unity! -"+this.name);
        SceneManager.SetActiveScene(this.gameObject.scene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
