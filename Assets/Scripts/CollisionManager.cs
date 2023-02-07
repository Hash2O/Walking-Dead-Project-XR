using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private UnityEvent collisionEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log(collision.collider.name + " est entr� en collision avec " + gameObject.name);
            collisionEvent.Invoke(); //On appelle l'�v�nement cr�� plus haut. Gestion via Unity
    }
}
