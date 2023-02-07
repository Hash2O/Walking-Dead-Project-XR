using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private float _rayLength; //Pour augmenter la port�e du ray
    [SerializeField] private float _snapSpeed;
    [SerializeField] private Transform _holdPosition; //L� o� l'objet sera tenu avec OnGrab

    [SerializeField] private Rigidbody _grabbedObject;
    private bool isGrabbed; // false par d�faut
    [SerializeField] private float _throwForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_grabbedObject)
        {
            //M�thode bourrinne avec AddForce et ForceMode
            //_grabbedObject.AddForce((transform.GetChild(0).position - _grabbedObject.transform.position) * _snapSpeed, ForceMode.Impulse);
            
            //M�thode plus douce, bas�e sur la vitesse de l'objet, et non une force impuls�e
            _grabbedObject.velocity = (_holdPosition.position - _grabbedObject.transform.position) * _snapSpeed;
        }
    }

    private void OnGrab() //ctrl + ; pour extraire une methode
    {
        if(!isGrabbed)
        {
            ShootRaycast(); //Shoot raycast et on attire l'objet cibl� compatible
            isGrabbed = true;
            if (_grabbedObject)
                {
                _grabbedObject.transform.parent = transform;    //Cr�er relation de parentalit� entre le player et l'objet grabb�
                }
        }
        else
        {
            if (_grabbedObject)
            {
                /*
                _grabbedObject.AddForce(_holdPosition.forward * _snapSpeed);
                OnThrowGrabbed();
                DroppedDragObject();  //On enl�ve la force pour relacher l'objet
               */
                OnThrowGrabbed(); 
            }
            isGrabbed = false;
        }
    }

    private void DroppedDragObject()
    {
        _grabbedObject.transform.parent = null;    //Destruction du lien parentalit� entre le player et l'objet grabb�
        _grabbedObject = null;
    }

    private void OnThrowGrabbed()
    {
        if(_grabbedObject)
        {
            _grabbedObject.AddForce(_holdPosition.forward * _throwForce);
            DroppedDragObject();
        }
    }

    private void ShootRaycast()
    {
        RaycastHit hit; //out hit permet de r�cup�rer des infos sur l'objet touch� par le raycast
        if (Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out hit, _rayLength))
        {
            Debug.Log("Le rayon a crois� " + hit.transform.name);
            if (hit.transform.CompareTag("Grabbable"))
            {
                //D�placer un objet dans Unity : destination - origine 
                //Ici, on l'attire
                if(hit.rigidbody != null)
                {
                    _grabbedObject = hit.rigidbody;
                }
                
                //hit.rigidbody.AddForce((transform.GetChild(0).position - hit.transform.position) * _snapSpeed, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;   //Pour mieux voir le ray

        //Dessiner un ray partant du player, et allant devant lui
        //Rattach� � playercapsule, on r�cup�re les infos de la cam�ra, premier enfant de playercapsule
        Gizmos.DrawRay(transform.GetChild(0).position, transform.GetChild(0).forward * _rayLength);
    }
}
