using System.Threading;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Cysharp.Threading.Tasks;

/// <summary>
/// A class for explicit initialization of UniTask by providing a synchronization context and main thread ID.
/// </summary>
public class UniTaskInjector
{
	/// <summary>
	/// Injects UniTask by setting the synchronization context, main thread ID, and initializing the PlayerLoop.
	/// If UniTask is already initialized, the method returns immediately.
	/// </summary>
	/// <param name="syncContext">The synchronization context (for example, SynchronizationContext.Current).</param>
	/// <param name="threadId">The main thread ID (for example, Thread.CurrentThread.ManagedThreadId).</param>
	public static void Inject(SynchronizationContext syncContext, int threadId)
	{
		if (PlayerLoopHelper.IsInjectedUniTaskPlayerLoop()) return;
		
		if (syncContext == null)
		{
			Debug.LogWarning("SynchronizationContext is null. Injection was not performed.");
			return;
		}

		PlayerLoopHelper.unitySynchronizationContext = syncContext;
		PlayerLoopHelper.mainThreadId = threadId;
		
		try
		{
			PlayerLoopHelper.applicationDataPath = Application.dataPath;
		}
		catch
		{
			// ignored
		}

		if (PlayerLoopHelper.runners != null)
		{
			Debug.Log("UniTask is already initialized: runners already exist.");
			return;
		}

		PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
		PlayerLoopHelper.Initialize(ref playerLoop);
	}
}