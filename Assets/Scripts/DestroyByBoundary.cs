using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
