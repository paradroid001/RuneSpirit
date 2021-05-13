using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GAD375.Prototyper;
namespace Punk.Runespirit
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(RSCharacter2D))]
    public class RSInteractable : Interactable
    {
        CircleCollider2D interactionCollider;
        RSCharacter2D rschar2d;
        // Start is called before the first frame update
        void Start()
        {
            interactionCollider = GetComponent<CircleCollider2D>();
            interactionCollider.radius = radius;
            rschar2d = GetComponent<RSCharacter2D>();
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Interaction>() != null)
            {
                Debug.Log("Interactor entered");
                rschar2d.OnBecomeInteractable();
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.GetComponent<Interaction>() != null)
            {
                Debug.Log("Interactor exited");
                rschar2d.OnBecomeUninteractable();
            }
        }

    }
}