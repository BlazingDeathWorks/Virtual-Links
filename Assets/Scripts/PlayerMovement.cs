using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 1;
    private Rigidbody2D rb = null;
    private Animator animator = null;
    private Vector2 movement;

    [SerializeField]
    private float audioPlayRate = 1.5f;
    private float time = 0;
    [SerializeField]
    private AudioClip[] walkingClips;
    private AudioSource audioSource = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        speed = Spawner.PrefabTransforms.Count;

        if(time <= 0)
        {
            if (walkingClips == null || movement == Vector2.zero || audioSource == null) return;
            audioSource.PlayOneShot(walkingClips[Random.Range(0, walkingClips.Length)]);
            time = audioPlayRate;
            return;
        }
        time -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * speed;
    }
}
