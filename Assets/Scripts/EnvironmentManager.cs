using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestState
{
    public TestState nextState;
    public EnvironmentManager owner;
    public bool hasFinished = false;

    public TestState(EnvironmentManager _owner)
    {
        owner = _owner;
    }

    public virtual void BeginState()
    {

    }

    public virtual void TickState()
    {

    }

    public virtual void EndState()
    {

    }
}

public class WaitState : TestState
{
    private float counter = 0;
    private float secondsToWait = 2;

    public WaitState(EnvironmentManager _owner) : base(_owner)
    {
        owner = _owner;
    }


    public override void BeginState()
    {
        //Debug.Log("waitstate begin!");
        secondsToWait = UnityEngine.Random.Range(2, 8);
        nextState = new RotateState(owner, .5f);
    }

    public override void TickState()
    {
        counter += Time.deltaTime;
        if (counter >= secondsToWait)
        {
            hasFinished = true;
        }
    }

    public override void EndState()
    {
        //Debug.Log("waitstate end!");
    }
}

public class RotateState : TestState
{
    float rotSpeed;
    float rotTotal;
    float difVal;
    float rotatedValue;

    public RotateState(EnvironmentManager _owner, float _rotSpeed) : base(_owner)
    {
        owner = _owner;
        rotSpeed = _rotSpeed;
        rotTotal = UnityEngine.Random.Range(20, 60);
    }

    public override void BeginState()
    {
        //Debug.Log("Rotatestate begin!");
        nextState = new WaitState(owner);
        difVal = Mathf.Round(UnityEngine.Random.Range(0, 2)) == 1 ? rotTotal : -rotTotal;
        rotatedValue = 0;
    }

    public override void TickState()
    {
        var val = rotSpeed * Time.deltaTime;
        if (difVal < 0) val *= -1;
        rotatedValue += val;
        
        //Inefficiente spaghetti
        owner.particleObject.transform.Rotate(Vector3.forward, val);
        var main = owner.particleObject.transform.GetChild(0).GetComponent<ParticleSystem>().main;
        main.startRotation = Mathf.Deg2Rad * owner.particleObject.transform.rotation.eulerAngles.z * -1;

        if ((difVal < 0 && rotatedValue <= difVal)||(difVal > 0 && rotatedValue >= difVal))
        {
            hasFinished = true;
        }
    }

    public override void EndState()
    {
        //Debug.Log("rotate end! ");
    }
}

public class EnvironmentManager : MonoBehaviour
{
    public GameObject particleObject;
    public TestState currentState;

    private void Start()
    {
        SwitchState(new WaitState(this));
    }

    public void SwitchState(TestState newState)
    {
        currentState?.EndState();
        currentState = newState;
        currentState?.BeginState();
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            if (currentState.hasFinished)
            {
                SwitchState(currentState.nextState);
            }
            else
            {
                currentState.TickState();
            }  
        } 
    }
}