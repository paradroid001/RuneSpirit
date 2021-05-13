using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Punk.Runespirit
{
    //This class should know enough about itself to know:
    //which direction it's moving in
    //whether or not it's on the ground
    //what animation it's playing, ability to change animations.
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Animator))]
    public class RSCharacter2D : Char2D
    {
        public float jumpPower = 3.0f;
        public float baseMoveSpeed = 5.0f;
        public Transform groundRayCast;
        public LayerMask whatIsGround;
        public Vector2 groundDetectorSize;
        protected Animator _animator;
        protected Rigidbody2D _rb2d;
        protected Collider2D _col2d;

        protected bool _grounded;

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        protected override void Init()
        {
            _animator = GetComponent<Animator>();
            _rb2d = GetComponent<Rigidbody2D>();
            _col2d = GetComponent<Collider2D>();
            base.Init();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        protected virtual void FixedUpdate()
        {
            float yvel = _rb2d.velocity.y;
            //if falling, check for ground.
            if (yvel < 0)
            {
                _grounded = CheckGround();
                //_animation.OnGround = grounded;
                //if grounded, yvel = 0;
               // if (_grounded)
               // {
               //     yvel = 0.0f;
               // }
            }

            _rb2d.velocity = new Vector2(currentMovement.x, yvel);
            
        }

        protected virtual void OnDrawGizmos() 
        {
            Gizmos.DrawWireCube(groundRayCast.position, new Vector3(groundDetectorSize.x, groundDetectorSize.y, 0));
        }

        public virtual void Jump()
        {
            if (_rb2d.velocity.y > 0.01f)
            {
                Debug.Log("Still moving up? Not jumping");
                return;
            }
            _grounded = CheckGround();
            if (_grounded)
            {
                _grounded = false;
                _rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                //_animation.OnGround = _grounded;
                Debug.Log("Jumped");
            }
            else
            {
                Debug.Log("Not jumping, wasn't grounded");
            }
        }

        protected virtual bool CheckGround()
        {
            Collider2D col = Physics2D.OverlapBox(groundRayCast.position, groundDetectorSize, 0, whatIsGround);
            if (col == null)
            {
                return false;
            }
            
            //Debug.Log(col.name);
            return true;
        }

        public virtual void OnBecomeInteractable()
        {
            _animator.SetBool("Interactable", true);
        }
        public virtual void OnBecomeUninteractable()
        {
            _animator.SetBool("Interactable", false);
        }
    }

}