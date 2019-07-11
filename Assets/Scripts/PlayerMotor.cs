using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent;
    public float walkSpeed;
    public Animator anim;

    public Interactable focus;
    public bool hasInteracted = false;

    // Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        if (anim == null)
        {
            Debug.LogWarning("No animator assigned! PlayerMotor needs an animator!");
        }
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);
        if (focus != null)
        {
            if (Vector3.Distance(transform.position, focus.transform.position) <= focus.radius && hasInteracted == false)
            {
                focus.Interact();
                transform.LookAt(focus.gameObject.transform);
                hasInteracted = true;
            }
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Defocus();
                agent.SetDestination(hitInfo.point);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    Defocus();
                    SetFocus(hitInfo.collider.GetComponent<Interactable>());
                }
            }
        }
	}
    public void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        hasInteracted = false;
        agent.stoppingDistance = focus.radius;
        agent.SetDestination(focus.gameObject.transform.position);
        
    }
    public void Defocus()
    {
        focus = null;
        hasInteracted = false;
        agent.stoppingDistance = 0;
    }

}
