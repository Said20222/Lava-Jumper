using UnityEngine;

public class CharacterController : MonoBehaviour {


	public Vector3 nextPos;
	public Vector3 currentWorldPos;
	public float jumpForce=100f;
	public float speed= 0.05f;
	public float speedRot=0.05f;

	public float rotationOffset=0;

	public bool canPlat = true;
	public Vector3 facingDir;

	public bool onPlatform;
	public GameObject pivotPoint;



	Rigidbody rb;
	// Use this for initialization


	void Start () {
		currentWorldPos = transform.position;
		rb = GetComponent<Rigidbody> ();
		facingDir = Vector3.forward;
	}




	
	// Update is called once per frame
	void Update () {



		if (transform.position != new Vector3 (currentWorldPos.x + nextPos.x, transform.position.y, currentWorldPos.z + nextPos.z)) {
			
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (currentWorldPos.x + nextPos.x, transform.position.y, currentWorldPos.z + nextPos.z), speed*Time.deltaTime);

		


		}
		else {

			nextPos = Vector3.zero;

			if (Input.GetAxisRaw ("Horizontal") != 0) {
				nextPos.x = Input.GetAxisRaw ("Horizontal");

			} else if (Input.GetAxisRaw ("Vertical") != 0) {
				nextPos.z = Input.GetAxisRaw ("Vertical");
			}

			//sets curposition
			currentWorldPos = transform.position;



	
		}

		}


	}
