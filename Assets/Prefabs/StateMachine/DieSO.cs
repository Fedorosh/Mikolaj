using Fedorosh.Dying;
using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Die", menuName = "State Machines/Actions/Die")]
public class DieSO : StateActionSO
{
	protected override StateAction CreateAction() => new Die();
}

public class Die : StateAction
{
	protected new DieSO OriginSO => (DieSO)base.OriginSO;

	private DyingObject dyingObject;

	public override void Awake(StateMachine stateMachine)
	{
		dyingObject = stateMachine.GetComponent<DyingObject>();
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
		DyingController.TriggerDieEvent?.Invoke(dyingObject);
	}
	
	public override void OnStateExit()
	{
	}
}
