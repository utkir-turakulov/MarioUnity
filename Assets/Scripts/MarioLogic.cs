using UnityEngine;

public class MarioLogic : MonoBehaviour {

    public float speed = 1.0f;
    public float jumpSpeed = 2f;
    public LayerMask groundlayer;
  //  public bool isTouched = true;

    private Animator marioAnimator;
    private Transform gCheck;
    private float scaleX = 3.164f;
    private float scaleY = 3.139f;
    public Vector3 jump;

	void Start () {
        marioAnimator = GetComponent<Animator>();
        gCheck = transform.Find("GCheck");
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void FixedUpdate()
    {
        float mSpeed = Input.GetAxis("Horizontal");
        marioAnimator.SetFloat("Speed", Mathf.Abs(mSpeed));

        bool isTouched = Physics2D.OverlapPoint(gCheck.position, groundlayer);

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Прыжок");
            Debug.Log(isTouched);
            if (isTouched)
            {
                Debug.Log("Достигнут земли");

                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                isTouched = false;
            }
        }

        marioAnimator.SetBool("isTouched", isTouched);

        if (mSpeed > 0)
        {
            transform.localScale = new Vector2(scaleX, scaleY);
        }
        else if (mSpeed < 0)
        {
            transform.localScale = new Vector2(-scaleX, scaleY);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(mSpeed * speed, GetComponent<Rigidbody2D>().velocity.y);
        //   GetComponent<Rigidbody2D>().AddForce(movement * mSpeed);
    }
}
