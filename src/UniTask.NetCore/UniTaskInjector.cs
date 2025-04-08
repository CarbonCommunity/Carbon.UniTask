using System.Threading;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Cysharp.Threading.Tasks;

public class UniTaskInjector
{
	public static void Inject(SynchronizationContext syncContext, int threadId)
	{
		if (PlayerLoopHelper.IsInjectedUniTaskPlayerLoop()) return;

		PlayerLoopHelper.unitySynchronizationContext = syncContext;
		PlayerLoopHelper.mainThreadId = threadId;
		try
		{
			PlayerLoopHelper.applicationDataPath = Application.dataPath;
		}
		catch { }
		
		if (PlayerLoopHelper.runners != null) return;

		PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
		PlayerLoopHelper.Initialize(ref playerLoop);
	}
}