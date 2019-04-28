using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (gameController.score > 200)
        {
            scrollSpeed = -4;
        }
	}
}
