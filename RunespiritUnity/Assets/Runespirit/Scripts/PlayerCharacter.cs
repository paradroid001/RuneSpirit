using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Punk.Runespirit
{
    public class PlayerCharacter : RSCharacter2D
    {
        public AnimationCurve accelerationCurve;
        public float accelerationTime = 1.4f;
        
        public float normalGravity;
        public float jumpGravity;
        float horizontalInputTimer;

        float horizInput;
        bool jumpInput;
        
        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {
            horizInput = Input.GetAxisRaw("Horizontal");
            jumpInput = Input.GetButton("Fire1");

            
            if (horizInput != 0)
            {
                horizontalInputTimer += Time.deltaTime;
                float accelerationSampleTime = Mathf.Min(horizontalInputTimer/accelerationTime, 1.0f);
                float accelerationValue = accelerationCurve.Evaluate(accelerationSampleTime);
                moveSpeed = accelerationValue * baseMoveSpeed;
                SetMovement(Vector2.right * horizInput);
            }
            else
            {
                horizontalInputTimer = 0;
                AccelerateMovement(new Vector2(0.95f, 1.0f));
            }

            /*
            if (jump)
            {
                _rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            */

            //SetMovement(Vector2.right * h); //movespeed is used here.
            //_rb2d.velocity = new Vector2(currentMovement.x, _rb2d.velocity.y);
            
            if (jumpInput && !_grounded)
            {
                _rb2d.gravityScale = jumpGravity;
            }
            else
            {
                _rb2d.gravityScale = normalGravity;
            }
            
            
        }

        protected override void FixedUpdate()
        {
            if (jumpInput)
            {
                Debug.Log("Jump Input");
                Jump();
                jumpInput = false;
            }
            base.FixedUpdate();
        }
    }
}
