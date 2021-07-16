using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private float h;
    private float v;
    [SerializeField] private float speed;

    [SerializeField] private Transform aim;

    [SerializeField] private Camera camera;

    [SerializeField] private Transform bulletPrefab;

    private Vector3 moveDirection;
    private Vector2 facingDirection;
    private bool gunLoaded = true;

    private int health = 5;

    [SerializeField]private float fireRate = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;
        transform.position += moveDirection * Time.deltaTime * speed;

        //Move aim

        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;

        if(Input.GetMouseButton(0) && gunLoaded){
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y,facingDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(bulletPrefab, transform.position, targetRotation);
            StartCoroutine(ReloadGun());
        }
    }

    public void TakeDamage() {
        health --;
        Debug.Log("me pegaste " + health);
    }

    private IEnumerator ReloadGun(){
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }
}
