// Stage 0 recovery infrastructure (RECONSTRUIDO: tooling, not game logic).
// Every original method whose body has not been translated from the ARM AOT code yet calls Hit().
// The first call per member is logged, so running the game tells which method to recover next.
using System.Collections.Generic;
using UnityEngine;

public static class RecoveryPending
{
    static readonly HashSet<string> s_Seen = new HashSet<string>();
    public static bool LogEnabled = true;

    public static IEnumerable<string> Seen { get { return s_Seen; } }

    public static void Hit(string member)
    {
        if (!s_Seen.Add(member)) return;
        if (LogEnabled) Debug.LogWarning("[RecoveryPending] " + member);
    }
}
