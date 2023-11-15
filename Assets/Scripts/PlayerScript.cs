using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    float horizontal;
    float vertical;

    [SerializeField] float runSpeed = 20.0f;

    [SerializeField] IntroText text;

    [SerializeField] Animator animator;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = animator.transform.localScale;
        if(FindObjectOfType<MenuMusic>()) FindObjectOfType<MenuMusic>().DestroyMusic();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

     
        animator.SetBool("Look Right", horizontal != 0);

        if (horizontal > 0)
        {
            animator.transform.localScale = new Vector3(-scale.x, scale.y, 1);
        }
        else if (horizontal < 0)
        {
            animator.transform.localScale = new Vector3(scale.x, scale.y, 1);
        }

        if(vertical > 0 && horizontal == 0)
        {
            animator.SetBool("Look Up", true);
        }
        else if(vertical < 0 || horizontal != 0)
        {
            animator.SetBool("Look Up", false);
        }

        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("Running", false);
            animator.SetBool("Look Up", false);
            animator.SetBool("Look Right", false);
        }
        else
        {
            animator.SetBool("Running", true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;
    }
    public void GameOver()
    {
       

        text.GameOver();
        Destroy(gameObject);

    }
}
