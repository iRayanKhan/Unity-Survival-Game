using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Player2Movement : MonoBehaviour
{ 
    public float Speed = 3.0F;
    public float RotateSpeed = 3.0F;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (transform != null)
        {
            transform.Rotate(0, Input.GetAxisRaw("Horizontal 2") * RotateSpeed, 0);
            var forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = Speed * Input.GetAxisRaw("Vertical 2");
            controller.SimpleMove(forward * curSpeed);
        }
    }
        void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal 2");
        float v = Input.GetAxisRaw("Vertical 2");
        
        Animating(h, v);

    }

   
       

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
