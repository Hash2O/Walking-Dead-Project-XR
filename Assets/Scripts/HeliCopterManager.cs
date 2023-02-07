using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCopterManager : MonoBehaviour
{
    private float speed = 12.0f;
    private float cityBound = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.z > cityBound)
        {
            speed = 0f;
            Debug.Log("Vehicle destroyed");
            //gameObject.SetActive(false);
        }
        
    }

    IEnumerator HeliCopterFlying()
    {
        yield return new WaitForSeconds(3.0f);
        print("Cops talking in CB");
    }
}
