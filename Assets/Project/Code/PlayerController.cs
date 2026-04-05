using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    private float speed = 30f;
    private int currentHP;
    private bool isFront = false;
    private bool isLeft = false;
    private bool isRight = false;
    private bool isBack = false;

    [SerializeField] Text hptext;
    [SerializeField] PlayerStatusSO playerStatusSO;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        hptext.GetComponent<Text>().text = "HP:" + currentHP;
        Debug.Log(currentHP);
    }

    void OnMove(InputValue value)
    {
        Debug.Log("Move:"+ value.Get<Vector2>());
        Vector2 v = value.Get<Vector2>();

        isFront = v.y > 0;
        isBack  = v.y < 0;
        isRight = v.x > 0;
        isLeft  = v.x < 0;

        animator.SetBool("Front", isFront);
        animator.SetBool("Back", isBack);
        animator.SetBool("Right", isRight);
        animator.SetBool("Left", isLeft);
    }

    // Update is called once per frame
    void Update()
    {
        hptext.GetComponent<Text>().text = "HP:" + playerStatusSO.HP;
    }

    private void FixedUpdate()
    {
        if (isFront)
        {
            rigidBody.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        if (isBack)
        {
            rigidBody.AddForce(transform.forward * speed * -1, ForceMode.Acceleration);
        }
        if (isRight)
        {
            rigidBody.AddForce(transform.right * speed, ForceMode.Acceleration);
        }
        if (isLeft)
        {
            rigidBody.AddForce(transform.right * speed * -1, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision");
        currentHP = currentHP - 10;
    }


}
