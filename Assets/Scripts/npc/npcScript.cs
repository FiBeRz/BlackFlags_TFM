using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    //Movement
    [SerializeField] private bool isMovable;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 1.5f;
    private int waypointIndex = 0;
    private bool moving = true;

    //Animation
    private Animator animator;

    //Appearance
    [SerializeField] private Material[] hairList;
    [SerializeField] private Material[] shirtList;
    [SerializeField] private Material[] skinList;
    Material[] materials;

    void Start()
    {
        changeAppearance();

        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }

        moving = true;
    }

    private void changeAppearance()
    {
        SkinnedMeshRenderer renderer = this.GetComponentInChildren<SkinnedMeshRenderer>();
        materials = renderer.materials;

        setMaterial(Random.Range(0, hairList.Length), Random.Range(0, skinList.Length), Random.Range(0, shirtList.Length));
        renderer.materials = materials;
    }

    void setMaterial(int hairNumber, int skinNumber, int shirtNumber)
    {
        //Change hair
        materials[8] = hairList[hairNumber];

        //Change skin
        materials[1] = skinList[skinNumber];
        materials[5] = skinList[skinNumber];
        materials[6] = skinList[skinNumber];

        //Change shirt
        materials[0] = shirtList[shirtNumber];
    }

    void Update()
    {
        if (moving && isMovable)
        {
            walk();
        }
    }

    private void walk()
    {
        moving = true;
        animator.SetBool("Walking", moving);

        if (waypointIndex == 0)
        {
            transform.position = waypoints[waypointIndex].transform.position;
            waypointIndex++;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.1f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                Destroy(this.gameObject);
            }
                
        }
    }

    private void stopWalking()
    {
        moving = false;
        animator.SetBool("Walking", moving);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            stopWalking();
            GameManager.Instance.notify();
            GameManager.Instance.showNPCText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (isMovable)
            {
                walk();
            }
            GameManager.Instance.endNotify();
            GameManager.Instance.hideNPCText();
        }
    }

    public void setWaypoints(GameObject[] waypointList)
    {
        waypoints = waypointList;
        isMovable = true;
    }
}
