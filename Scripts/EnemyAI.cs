using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public Transform target;
	public float rotationSpeed;
	public float moveSpeed;
    //public Animator enemyAnim;
	public Rigidbody enemyRB;

    // Start is called before the first frame update
    void Start()
    {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //If distance between target and enemy is less than 2 units and greater than 1
		if(Vector3.Distance(transform.position, target.position) < 10 
			&& Vector3.Distance(transform.position, target.position) > 2)
		{
			//store direction to move
			Vector3 moveDir = target.position - transform.position;

			//make sure the enemy doesn't try to move off the ground
			moveDir = new Vector3(moveDir.x, 0, moveDir.z);

			//move the enemy through the rigidbody
			enemyRB.MovePosition(enemyRB.position + moveDir.normalized * Time.deltaTime * moveSpeed);
          //  enemyAnim.SetTrigger("Move");

			//store direction to face
			Quaternion direction = Quaternion.LookRotation(target.position);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, rotationSpeed);
		}
    }
}
