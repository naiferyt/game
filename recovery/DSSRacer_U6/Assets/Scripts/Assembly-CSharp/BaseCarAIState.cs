// Base of the CarAI state machine (drive waypoints, avoid terrain, get pickup, hit beneficial, use powerup).
// RECUPERADO-AOT BaseCarAIState::.ctor token 0x0600002b @0x000c4ad8 (trivial constructor)
public abstract class BaseCarAIState
{
	public CarAI parentAI;

	public abstract CarAI.AIStates GetAIStateEnum();

	public abstract void Init();

	public abstract void Update();

	public abstract void FixedUpdate();

	public abstract void Shutdown();
}
