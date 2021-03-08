using UnityEngine;
using System.Linq;

public class TargetMoverV2 : MonoBehaviour
{
    public LayerMask mask;

    public Transform target;
    Pathfinding.IAstarAI[] ais;
    
    public bool onlyOnDoubleClick;
    public bool use2D;

    Camera cam;

    public void Start()
    {
        cam = Camera.main;
        ais = FindObjectsOfType<MonoBehaviour>().OfType<Pathfinding.IAstarAI>().ToArray();
        useGUILayout = false;
    }
    
    void Update()
    {
        if (DialogueManager.instance.inDialogue) return;
        if (Input.GetMouseButtonDown(0) && cam != null)
        {
            UpdateTargetPosition();
        }
    }

    public void UpdateTargetPosition()
    {
        Vector3 newPosition = Vector3.zero;
        bool positionFound = false;

        if (use2D)
        {
            newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            positionFound = true;
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
            {
                newPosition = hit.point;
                positionFound = true;
            }
        }

        if (positionFound && newPosition != target.position)
        {
            target.position = newPosition;

            if (onlyOnDoubleClick)
            {
                for (int i = 0; i < ais.Length; i++)
                {
                    if (ais[i] != null) ais[i].SearchPath();
                }
            }
        }
    }
}