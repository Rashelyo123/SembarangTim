using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public enum SIDE { Left, Mid, Right }

public class PlayerController : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    [HideInInspector]
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    public float XValue;

    private CharacterController m_char;
    private float x;
    public float SpeedDodge;
    public float JumpPower = 7f;
    private float y;
    public bool inJump;
    public bool InSlide;
    private float ColHeight;
    private float ColCenterY;

    void Start()
    {
        m_char = GetComponent<CharacterController>();
        ColHeight = m_char.height;
        ColCenterY = m_char.center.y;
        transform.position = Vector3.zero;

    }
    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        SwipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        if (!InSlide)
            if (SwipeLeft && !InSlide)
            {
                if (m_Side == SIDE.Mid)
                {
                    NewXPos = -XValue;
                    m_Side = SIDE.Left;
                }
                else if (m_Side == SIDE.Right)
                {
                    NewXPos = 0f;
                    m_Side = SIDE.Mid;

                }
            }
        if (SwipeRight && !InSlide)
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = XValue; m_Side = SIDE.Right;

            }
            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0f;
                m_Side = SIDE.Mid;
            }
        }
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, 0);
        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * SpeedDodge);
        m_char.Move(moveVector);
        Jump();
        Slide();
    }

    public void Jump()
    {
        if (m_char.isGrounded)
        {
            if (SwipeUp)
            {
                y = JumpPower;
                inJump = true;

            }
        }
        else
        {
            y -= JumpPower * 2 * Time.deltaTime;
            if (m_char.velocity.y < 0.1f)
                Debug.Log("Fall");
        }


    }
    internal float SlideCounter = 0f;
    public void Slide()
    {
        if (SwipeDown && !InSlide)
        {
            SlideCounter = 0.2f;
            y -= 10f;
            m_char.center = new Vector3(0, ColCenterY / 2f, 0);
            m_char.height = ColHeight / 2f;
            InSlide = true;
            inJump = false;
        }

        if (InSlide)
        {
            SlideCounter -= Time.deltaTime;

            if (SlideCounter <= 0f)
            {
                m_char.center = new Vector3(0, ColCenterY, 0);
                m_char.height = ColHeight;
                InSlide = false;
            }
        }
    }


}
