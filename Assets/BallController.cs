using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	//static int score;

	public Rigidbody playerRigidBody;
	//public GameObject playerShadow;

	//private Vector3 playerShadowOffset = new Vector3(0.02f, 0, -0.2f);
	//private float sensitivityMultiplier = 2.5f;

	//private Vector3 playerShadowOffset = new Vector3(0.04f, 0, -0.3f);
	private float sensitivityMultiplier = 2.0f;
	private float speed;

	void Main ()
	{	
		// Preventing mobile devices going in to sleep mode 
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	void start()
	{
		playerRigidBody = GetComponent<Rigidbody>();
	}

	void LateUpdate () 
	{
		//playerShadow.transform.position = transform.position + playerShadowOffset;
	}
	
	void FixedUpdate () 
	{
		Physics.gravity = Vector3.down * 50;
		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{
			speed = 3000;
			//get input by keyboard
			float movehorizontal = Input.GetAxis ("Horizontal");
			float movevertical = Input.GetAxis ("Vertical");			
			Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertical);
			playerRigidBody.AddForce (movement * speed * Time.deltaTime);
			//playerRigidBody.velocity = movement * speed * Time.deltaTime;
		} else 
		{
			speed = 4500;
			// Player movement in mobile devices
			// Building of force vector 
			Vector3 movement = new Vector3 (Input.acceleration.x * sensitivityMultiplier, 0.0f, Input.acceleration.y * sensitivityMultiplier);
			// Adding force to rigidbody
			playerRigidBody.AddForce (movement * speed * Time.deltaTime);

		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
			string collidedObject = other.gameObject.tag;
		 	switch (collidedObject) {
		 	case "enemy":
			 			Time.timeScale = 0;
		// 			playerShadow.SetActive(false);
		// 			Invoke ("closeApp", 1);
		 			break;
		// 	case "Coin":
		// 			score = score + 1;   
		// 			break;
		// 	case "TimeoutBox":
		// 			Invoke ("gameTimeOut", 5);	
		// 			break;
		// 	case "Spring-Z":
		// 			Invoke ("throwBallFromSpringOn_Z_axis", 0.5f);
		// 			break;
		// 	case "Spring-X":
		// 			Invoke ("throwBallFromSpringOn_X_axis", 0.5f);
		// 			break;
		// 	case "SpringMinus-X":
		// 			Invoke ("throwBallFromSpringOnMinus_X_axis", 0.5f);
		// 			break;
		// 	case "Bomb":
		// 			Invoke ("gameTimeOut", 2);
		// 	      	break;
		// 	case "Hole":
		// 			Physics.gravity = Vector3.down * 1000;
		// 			Invoke ("gameTimeOut", 2);
		// 			break;
		 	default:
		 			break;
		 		}

	 }

	// void OnTriggerExit(Collider other)
	// {
	// 	if (other.gameObject.CompareTag ("TimeoutBox") || other.gameObject.CompareTag ("Hole"))
	// 	{ 
	// 		CancelInvoke("gameTimeOut");
	// 	}
	// }

	// void throwBallFromSpringOn_Z_axis()
	// {
	// 	playerRigidBody.velocity += new Vector3(0,0,30);
	// }

	// void throwBallFromSpringOn_X_axis()
	// {
	// 	playerRigidBody.velocity += new Vector3(30,0,0);
	// }

	// void throwBallFromSpringOnMinus_X_axis()
	// {
	// 	playerRigidBody.velocity += new Vector3(-30,0,0);
	// }

	// void gameTimeOut()
	// {
	// 	Application.LoadLevel (Application.loadedLevel);
	// }


	// void OnGUI()
	// {
	// 	GUILayout.Label( Application.loadedLevelName );
	// 	GUILayout.Label( "\n Score = " + score );
	// }


	// void closeApp()
	// {
	// 	if (Application.loadedLevel == 9) {
	// 		Application.Quit ();

	// 	} else {
	// 		Application.LoadLevel(Application.loadedLevel+1);
	// 	}

	// 	//Application.Quit();
	// 	//if(Application.loadedLevel == 2){
	// 	//Application.LoadLevel("Level_1");
		
	// 	//}else{
	// 	//	Application.LoadLevel (Application.loadedLevel+1);
	// 	//}
	// 	//Application.LoadLevel (Application.loadedLevel);
	// }
}
