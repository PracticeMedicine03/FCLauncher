using System;

namespace PracticeMedicine.SourceModInstaller
{
    public class SModInstaller
    {
        public static void InstallMod(string type, string link, string directory)
        {
            if(type == "git")
            {
                Git.Clone(true, link, directory);
            }
            else if (type == "webclient")
            {
                throw new NotImplementedException("SMOD Installer: The implementation of using the C# WebClient is not fully implemented yet. Check the FCLauncher repository for updates.");
            }
            else
            {
                throw new ArgumentNullException("SMOD Installer: There is no package manager type. Please specify an package manager type.");
            }
        }

        public static void UpdateMod(string type, string link, string directory)
        {
            if (type == "git")
            {
                Git.Pull(true, directory);
            }
            else if (type == "webclient")
            {
                throw new NotImplementedException("SMOD Installer: The implementation of using the C# WebClient is not fully implemented yet. Check the FCLauncher repository for updates.");
            }
            else
            {
                throw new ArgumentNullException("SMOD Installer: There is no package manager type. Please specify an package manager type.");
            }
        }
    }
}