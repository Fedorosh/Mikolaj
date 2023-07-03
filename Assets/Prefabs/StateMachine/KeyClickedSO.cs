using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "KeyClicked", menuName = "State Machines/Conditions/Key Clicked")]
public class KeyClickedSO : StateConditionSO
{
    [SerializeField] private KeyCode keyToPress;
    protected override Condition CreateCondition() => new KeyClicked(keyToPress);
}

public class KeyClicked : Condition
{
	private KeyCode keyToPress;

    public KeyClicked(KeyCode keyToPress)
    {
        this.keyToPress = keyToPress;
    }

    protected new KeyClickedSO OriginSO => (KeyClickedSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	protected override bool Statement()
	{
		return Input.GetKeyDown(keyToPress);
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
