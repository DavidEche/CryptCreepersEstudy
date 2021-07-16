using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 1;

    [SerializeField] private Transform player;

    [SerializeField] private float speed;

    private void Start() {
        player = FindObjectOfType<Player>().transform;
    }

    public void TakeDamage(){
        health--;
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Player>().TakeDamage();
        }
    }

    private void Update() {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction*Time.deltaTime * speed;
    }

}
