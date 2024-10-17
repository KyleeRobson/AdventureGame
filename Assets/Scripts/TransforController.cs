using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransforController : MonoBehaviour
{
   
    // Update is called once per frame
    private void Update()
    {
        // Move the target GameObject
        var x = Mathf.PingPong(Time.time, 3);
        var p = new Vector3(0, x, 0);
        transform.position = p;

        // Rotate the target GameObject
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
