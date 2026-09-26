public static class QualityControl
{
	public static bool IsGameHardcore
	{
		get
		{
			RecoveryPending.Hit("QualityControl.get_IsGameHardcore");
			return default(bool);
		}
	}

	public static bool DoPhysicsAt30fps
	{
		get
		{
			RecoveryPending.Hit("QualityControl.get_DoPhysicsAt30fps");
			return default(bool);
		}
	}

	public static bool DoPerFrameCollision
	{
		get
		{
			RecoveryPending.Hit("QualityControl.get_DoPerFrameCollision");
			return default(bool);
		}
	}

	public static bool DoDummiedPlayerCollision
	{
		get
		{
			RecoveryPending.Hit("QualityControl.get_DoDummiedPlayerCollision");
			return default(bool);
		}
	}

	public static bool DoFullTriFoot
	{
		get
		{
			RecoveryPending.Hit("QualityControl.get_DoFullTriFoot");
			return default(bool);
		}
	}

	public static bool DoFullAI
	{
		get
		{
			RecoveryPending.Hit("QualityControl.get_DoFullAI");
			return default(bool);
		}
	}

	public static void Apply()
	{
		RecoveryPending.Hit("QualityControl.Apply");
	}
}
