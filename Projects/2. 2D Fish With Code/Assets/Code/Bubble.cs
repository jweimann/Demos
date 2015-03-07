using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	[SerializeField]
	private float _maxHeight = 30f;

	[SerializeField]
	private float _startingHeight = -5f;

	[SerializeField]
	private float _minSpeed = 1f;

	[SerializeField]
	private float _maxSpeed = 5f;

	private float _speed;

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y >= _maxHeight || _speed == 0)
		{
			transform.position = new Vector3(transform.position.x, _startingHeight, transform.position.z);
			_speed = Random.Range(_minSpeed, _maxSpeed);
			GetComponent<SpriteRenderer>().enabled = true;
			GetComponent<CircleCollider2D>().enabled = true;
		}

		Vector3 movement = new Vector3(0, Time.deltaTime * _speed, 0);

		transform.position = transform.position + movement;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Entered Bubble Trigger " + other.name);
		
		var myScoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
		
		myScoreKeeper.IncrementScore();

		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<CircleCollider2D>().enabled = false;
	}
}
