using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDistance;
    [SerializeField] private float shotDelay;
    [SerializeField] private Transform shotPoint;
    private float lastShoot;
    private Vector2 movement;
    private Vector2 handlerDirection;
    private Vector2 shoot;
    private bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        shoot.x = Input.GetAxisRaw("ShootHorizontal");
        shoot.y = Input.GetAxisRaw("ShootVertical");

        Debug.Log(Input.GetAxis("ShootHorizontal"));
        Debug.Log(Input.GetAxis("ShootVertical"));


        if ((shoot.x != 0 || shoot.y != 0) && Time.time > lastShoot + shotDelay)
        {
            Shoot(shoot.x, shoot.y);
            lastShoot = Time.time;
        }

        if (!isShooting)
        {
            handlerDirection = movement;
        }
        else
        {

        }

        animator.SetFloat("Horizontal", handlerDirection.x);
        animator.SetFloat("Vertical", handlerDirection.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform. rotation) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x<0) ? Mathf.Floor(x)*bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
            (y<0) ? Mathf.Floor(y)* bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
            0
            );
    }

    private void FixedUpdate()
    {
        playerMovement.Mover(movement);
        playerMovement.Flip(movement.x);
    }
}
