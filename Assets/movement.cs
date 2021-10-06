using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float move_speed = 3.0f;
    public float jump_force = 3.0f;
    public SpriteRenderer render;
    Vector2 direction = Vector2.zero;
    bool isGround = true;
    bool isJump = false;

    public AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left * move_speed;
            direction.y = rigid.velocity.y;
            rigid.velocity = direction;
            render.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right * move_speed;
            direction.y = rigid.velocity.y;
            rigid.velocity = direction;
            render.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            Jump();
            isJump = true;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && isJump)
        {
            Jump();
            isJump = false;
        }

        
    }

    private void Jump()
    {
        audioSource.clip = clip;
        audioSource.volume = SoundManager.Instance.volume;
        audioSource.Play();
        rigid.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
        isGround = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Ground")
            isGround = true;
    }
}
