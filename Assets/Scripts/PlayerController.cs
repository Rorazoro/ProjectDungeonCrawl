using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private int direction = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {

        //Get movement vector
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);

        direction = getDirection(move);
    }

    private int getDirection(Vector2 move) {
        if (move.x > 0) {
            return 1;
        }
        else if (move.x < 0) {
            return 3;
        }
        else if (move.y > 0) {
            return 0;
        }
        else if (move.y < 0) {
            return 2;
        }
        else {
            return direction;
        }
    }
}
