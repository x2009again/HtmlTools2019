using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace HtmlTools
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [Guid("3e13f8c1-7dbc-4422-a281-055d45e2909e")]
    public sealed class HtmlToolsPackage : AsyncPackage
    {


    }
}
