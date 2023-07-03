using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "NewCondition", menuName = "State Machines/Conditions/New Condition")]
public class NewConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new NewCondition();
}

public class NewCondition : Condition
{
	protected new NewConditionSO OriginSO => (NewConditionSO)base.OriginSO;

	private DyingObject dyingObject;

	public override void Awake(StateMachine stateMachine)
	{
		dyingObject = stateMachine.GetComponent<DyingObject>();
	}
	
	protected override bool Statement()
	{
		if(dyingObject.LastEnemyInfo != null)
			return true;
		return false;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
