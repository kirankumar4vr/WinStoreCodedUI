using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Configuration;
using Pearson.PSCWinAutomation.Framework;
using System.Drawing;



namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for ResourceLibraryCommonMethods
    /// </summary>
    
    public class ResourceLibraryCommonMethods
    {
        public static bool VerifyResourceLibraryMenuItems()
        {
            return
            (
            AutomationAgent.VerifyControlExists("ResourceLibraryView", "VocabularyBtn") &&
            AutomationAgent.VerifyControlExists("ResourceLibraryView", "ToolsBtn") &&
            AutomationAgent.VerifyControlExists("ResourceLibraryView", "GamesBtn") && 
            AutomationAgent.VerifyControlExists("ResourceLibraryView", "RubricsBtn") &&
            AutomationAgent.VerifyControlExists("ResourceLibraryView", "GlossaryBtn") &&
            AutomationAgent.VerifyControlExists("ResourceLibraryView", "StandardsChartsBtn"));
        }

        public static bool VerifyResourceLibraryIcon()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames");
        }

        public static void CloseResourceLibraryMenu()
        {
            NavigationCommonMethods.ClickSystemTrayButton();
        }

        public static bool VerifyFlyOutMenuHeadingIsResourceLibrary()
        {
            return AutomationAgent.VerifyControlExists("ResourceLibraryView", "ResourceLibraryFlyoutHeader");
        }
    }
}
