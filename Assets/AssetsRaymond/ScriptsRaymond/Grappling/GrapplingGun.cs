using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, cam, player;
    private CharacterController charCon; // CharacterController of the player
    private float maxDistance = 1000f;
    private bool isGrappling = false;
    private float speed = 30f; // Speed at which the player moves to the grapple point
    private Coroutine moveCoroutine; // To handle the coroutine that moves the player

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        charCon = player.GetComponent<CharacterController>(); // Ensure the player has a CharacterController component
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            isGrappling = true;
            lr.positionCount = 2;

            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(MoveToGrapplePoint(grapplePoint));
        }
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        isGrappling = false;
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
    }

    IEnumerator MoveToGrapplePoint(Vector3 targetPoint)
    {
        while (Vector3.Distance(player.position, targetPoint) > 0.5f) // Increased stopping distance for smoother stopping
        {
            Vector3 direction = (targetPoint - player.position).normalized;
            charCon.Move(direction * speed * Time.deltaTime);
            yield return null;
        }
    }

    void DrawRope()
    {
        if (!isGrappling) return;

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    public bool IsGrappling()
    {
        return isGrappling;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
