using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private Rigidbody2D rigidbody2d = null;
    [SerializeField] private Animator animator = null;
    #endregion

    #region PRIVATE_FIELDS
    private static readonly int walkingId = Animator.StringToHash("Walking");
    #endregion
    
    #region UNITY_CALLS
    private void Update()
    {
        Move();
    }
    #endregion

    #region PRIVATE_METHODS
    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal == 0 && moveVertical == 0)
        {
            animator.SetBool(walkingId, false);
            rigidbody2d.velocity = Vector2.zero;
            return;
        }
        
        animator.SetBool(walkingId, true);
        
        switch (moveHorizontal)
        {
            case > 0:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Debug.Log("Moving right");
                break;
            case < 0:
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                Debug.Log("Moving left");
                break;
        }
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody2d.velocity = movement * speed;
    }
    #endregion
}