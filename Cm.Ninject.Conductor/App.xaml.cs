using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Cm.Ninject.Conductor
{
    using System.Runtime;

    public partial class App : Application
    {
        private static readonly string DirectoryName = "AppProfileOptimization";
        private static readonly string ProfileFile = "AppProfile";

        public App()
        {
            ProfileOptimization.SetProfileRoot(DirectoryName); 
            ProfileOptimization.StartProfile(ProfileFile);

        }
    }
}
