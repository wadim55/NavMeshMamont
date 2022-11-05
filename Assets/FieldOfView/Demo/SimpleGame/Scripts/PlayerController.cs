using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    
    
    public GameObject NavigationSurface;
    private NavMeshAgent _navMeshAgent;


    private void Start() {
        this._navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        
        
        // mouse click
        if (Input.GetMouseButtonUp(0)) {
            MovePlayerTo(Input.mousePosition);
        }
        // tap on touch screen
        else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            MovePlayerTo(Input.GetTouch(0).position);
        }
    }

    private void MovePlayerTo(Vector3 position) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == this.NavigationSurface) {
                this._navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}