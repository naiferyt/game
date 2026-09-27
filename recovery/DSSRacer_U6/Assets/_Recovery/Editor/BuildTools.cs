// Stage 4 build tooling (RECONSTRUIDO: tooling). Builds the Windows player from the Build Settings scenes.
// Usage (batch): Unity -batchmode -quit -projectPath <p> -executeMethod DSSRecovery.BuildTools.BuildWindows
//                      [-buildOut "<dir>"] [-development]
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace DSSRecovery
{
	public static class BuildTools
	{
		static string Arg(string name, string def)
		{
			var a = Environment.GetCommandLineArgs();
			int i = Array.IndexOf(a, name);
			if (i < 0 || i + 1 >= a.Length || a[i + 1].StartsWith("-")) return def;
			return a[i + 1];
		}

		public static void BuildWindows()
		{
			string outDir = Arg("-buildOut", Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "build", "Windows")));
			Directory.CreateDirectory(outDir);
			var scenes = EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
			var options = new BuildPlayerOptions
			{
				scenes = scenes,
				locationPathName = Path.Combine(outDir, "DSSRacer.exe"),
				target = BuildTarget.StandaloneWindows64,
				options = Environment.GetCommandLineArgs().Contains("-development") ? BuildOptions.Development : BuildOptions.None
			};
			BuildReport report = BuildPipeline.BuildPlayer(options);
			Debug.Log("[build] result " + report.summary.result + ", " + report.summary.totalErrors + " errors, " + (report.summary.totalSize / (1024 * 1024)) + " MB, " + report.summary.totalTime + " -> " + options.locationPathName);
			if (Application.isBatchMode) EditorApplication.Exit(report.summary.result == BuildResult.Succeeded ? 0 : 1);
		}
	}
}
