public abstract class BaseCarAIState
{
	public CarAI parentAI;

	public abstract CarAI.AIStates GetAIStateEnum();

	public abstract void Init();

	public abstract void Update();

	public abstract void FixedUpdate();

	public abstract void Shutdown();
}
