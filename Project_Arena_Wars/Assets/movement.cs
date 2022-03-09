using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class movement : MonoBehaviour
{
	public static movement instance;
	private bool drag;                  // True if is being dragged
	private Rigidbody2D myRigidbody;    // Reference to the GameObject's Rigidbody2D
	private bool wasKinematic;          // Flag indicating whether or not the Ridigbody
	public GameObject player;
	Vector2 speed = new Vector2(-3f,0.0f);
	public bool hostageTaken = false;
	bool hostageExtracted = false;

	// Use this for initialization
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		wasKinematic = myRigidbody.isKinematic;
	}

	// Update is called once per frame
	void Update()
	{
		if (hostageExtracted == true && Input.GetKey("E"))
        {
			Debug.Log("Put endscreen here");
			SceneManager.LoadScene("EndScreen");
		}

		if (drag == true)
		{
			DragFunction();
		}

		if (gameObject.transform.position.x <= -70.0f)
		{
			gameObject.transform.position = new Vector2(-75.0f, 0.0f);
		}

        if (hostageExtracted)
        {
			gameObject.GetComponent<Rigidbody2D>().AddForce(speed, ForceMode2D.Impulse);
		}
	}

	// Checks if the mouse button is pressed
	void OnMouseDown()
	{
		drag = true;
		myRigidbody.isKinematic = true;
	}

	// Checks if the mouse button is released
	void OnMouseUp()
	{

		// Update flags
		if (drag == true)
			myRigidbody.isKinematic = wasKinematic;
		drag = false;
	}

	void DragFunction()
	{
		// We are converting a 2D mouse coordinate to 3D
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
		// Update GameObject position
		transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Player" && hostageTaken == true)
        {
			hostageExtracted = true;
			Debug.Log("Hostage Saved!");
		}
    }
}
