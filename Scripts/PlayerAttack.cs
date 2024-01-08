using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Collider sword;
	public Animator playerAnim;



	// Start is called before the first frame update
	void Start()
	{
        sword.enabled = false;

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            sword.enabled = true;
            playerAnim.SetTrigger("attack");
        }
    }
}