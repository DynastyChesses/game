using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.iOS.Xcode;

namespace MobileSDK.Account
{
    public class GameCenterBuildPostProcess : IPostprocessBuildWithReport
    {
        public int callbackOrder => 2;

        public void OnPostprocessBuild(BuildReport report)
        {
            if (report.summary.platform != UnityEditor.BuildTarget.iOS)
                return;

            string pbxPath = PBXProject.GetPBXProjectPath(report.summary.outputPath);
            PBXProject pbxProject = new PBXProject();
            pbxProject.ReadFromFile(pbxPath);

            string targetGuid = pbxProject.GetUnityFrameworkTargetGuid();

            ProjectCapabilityManager pcm = new ProjectCapabilityManager(
                pbxPath,
                "Entitlements.entitlements",
                null,
                targetGuid
            );

            // 启用GameCenter
            pcm.AddGameCenter();

            pcm.WriteToFile();
        }
    }
}
