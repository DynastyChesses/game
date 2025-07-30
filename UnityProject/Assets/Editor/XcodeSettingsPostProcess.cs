using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.iOS.Xcode;

namespace MobileSDK.Ad
{
    public class MaxSDKXcodeSettingsPostProcess : IPostprocessBuildWithReport
    {
        public int callbackOrder => 1;

        public void OnPostprocessBuild(BuildReport report)
        {
            if (report.summary.platform != UnityEditor.BuildTarget.iOS)
                return;

            string projectPath = PBXProject.GetPBXProjectPath(report.summary.outputPath);
            PBXProject pbxProject = new PBXProject();
            pbxProject.ReadFromFile(projectPath);

            string targetGuid = pbxProject.GetUnityMainTargetGuid();

            // 修改BitCode
            pbxProject.SetBuildProperty(targetGuid, "ENABLE_BITCODE", "NO");

            // 保存修改
            pbxProject.WriteToFile(projectPath);

            // 修改Info.plist
            string plistPath = report.summary.outputPath + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromFile(plistPath);
            PlistElementDict rootDict = plist.root;
            rootDict.SetString(
                "NSUserTrackingUsageDescription",
                "We need your consent to provide personalized advertising and analysis. "
            );
            plist.WriteToFile(plistPath);
        }
    }
}
