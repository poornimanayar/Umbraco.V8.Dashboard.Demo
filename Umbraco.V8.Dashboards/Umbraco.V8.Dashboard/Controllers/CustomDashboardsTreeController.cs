using System.Net.Http.Formatting;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace Umbraco.V8.Dashboard.Controllers
{
    [Tree("giphySection", "giphySectionTreeAlias", IsSingleNodeTree = true)]
    [PluginController("giphySectionArea")]
    public class CustomDashboardsTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            //full screen app without tree nodes
            return TreeNodeCollection.Empty;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            //doesn't have a menu, this is a full screen app without tree nodes
            return MenuItemCollection.Empty;
        }
        }
    }