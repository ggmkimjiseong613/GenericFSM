using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class PlayerFSM : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    public InputReader PlayerInput => inputReader;

    [SerializeField] private float moveSpeed;
    public float MoveSpeed => moveSpeed;

    public StateMachine<PlayerFSM, PlayerStateEnum> stateMachine;
    public Rigidbody2D RigidbodyCompo { get; private set; }
    public Animator AnimatorCompo { get; private set; }

    public int FacingDirection { get; private set; } = 1;
    private void Awake()
    {
        RigidbodyCompo = GetComponent<Rigidbody2D>();
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();

        stateMachine = new StateMachine<PlayerFSM, PlayerStateEnum>();

        foreach(PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();
            Debug.Log(typeName);
            try
            {
                Type type = Type.GetType($"Player{typeName}State");
                PlayerState stateInstance = Activator.CreateInstance(type, this, stateMachine, typeName) as PlayerState;

                stateMachine.AddState(stateEnum , stateInstance);
            }
            catch(Exception e)
            {
                Debug.Log($"{typeName} 클래스 인스턴스를 생성할 수 없습니다. {e.Message}");
            }
        }

    }

    private void Start()
    {
        stateMachine.Initialize(PlayerStateEnum.Idle, this);
    }
    void Update()
    {
        stateMachine.CurrentState.Update();
    }

    public void SetVelocity(float x, float y, bool doNotFlip = false)
    {
        RigidbodyCompo.velocity = new Vector2(x, y);
        if (!doNotFlip)
        {
            FlipController(x);
        }
    }

    public void StopImmediately(bool withYAxis)
    {
        if (withYAxis)
        {
            RigidbodyCompo.velocity = Vector2.zero;
        }
        else
        {
            RigidbodyCompo.velocity = new Vector2(0, RigidbodyCompo.velocity.y);
        }
    }

    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0, 180f, 0);
    }

    public void FlipController(float x)
    {
        bool gotoRight = x > 0 && FacingDirection < 0; //InputX == true && InputX != currentX 
        bool gotoLeft = x < 0 && FacingDirection > 0;

        if(gotoRight || gotoLeft)
        {
            Flip();
        }
    }
}
