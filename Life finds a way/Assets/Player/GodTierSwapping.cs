using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodTierSwapping : MonoBehaviour {

	public int state = 1;
	public bool colide = false;
	public GameObject avatar1, avatar2, avatar3;
	void Start(){
		avatar1.gameObject.SetActive (true);
		avatar2.gameObject.SetActive (false);
		avatar3.gameObject.SetActive (false);
	}
	

	void Update(){
			
			switch (state) {
				case 1: //solid	
						//scripts
						this.GetComponent<Jump>().enabled = true;	
						this.GetComponent<Fly>().enabled = false;
						this.GetComponent<Blob>().enabled = false;
						//looks
						avatar1.gameObject.SetActive (true);
						avatar2.gameObject.SetActive (false);
						avatar3.gameObject.SetActive (false);
						//gravity
						this.GetComponent<Rigidbody2D>().gravityScale = 2f;
						//rotation
						this.GetComponent<Rigidbody2D>().freezeRotation = false;
						

					break;
				case 2: //fly
						//scripts
						this.GetComponent<Fly>().enabled = true;
						this.GetComponent<Jump>().enabled = false;
						this.GetComponent<Blob>().enabled = false;
						//looks
						avatar1.gameObject.SetActive (false);
						avatar2.gameObject.SetActive (true);
						avatar3.gameObject.SetActive (false);
						//gravity
						this.GetComponent<Rigidbody2D>().gravityScale = 0f;
						//rotation
						this.GetComponent<Rigidbody2D>().freezeRotation = true;
					break;
				case 3: //liquid snake
						//scripts
						this.GetComponent<Blob>().enabled = true;
						this.GetComponent<Fly>().enabled = false;
						this.GetComponent<Jump>().enabled = false;
						//looks
						avatar1.gameObject.SetActive (false);
						avatar2.gameObject.SetActive (false);
						avatar3.gameObject.SetActive (true);
						//gravity
						this.GetComponent<Rigidbody2D>().gravityScale = 0.6f;
						//rotation
						this.GetComponent<Rigidbody2D>().freezeRotation = true;
					break;
			}

		
	}
}
