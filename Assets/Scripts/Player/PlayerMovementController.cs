using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private float _movementSpeed = 1;
        private Rigidbody2D _rbody;

        void Start()
        {
            _rbody = GetComponent<Rigidbody2D>();
        }
    
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _rbody.AddForce(transform.up * _movementSpeed, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, 2);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -2);
            }

            BorderControl();
        }

        private void BorderControl()
        {
            if (transform.position.x > 9)
            {
                transform.position = new Vector2(-9, transform.position.y);
            }
            else if (transform.position.x < -9)
            {
                transform.position = new Vector2(9, transform.position.y);
            }
            else if (transform.position.y < -6)
            {
                transform.position = new Vector2(transform.position.x, 6);
            }
            else if (transform.position.y > 6)
            {
                transform.position = new Vector2(transform.position.x, -6);
            }
        }
    }
}
