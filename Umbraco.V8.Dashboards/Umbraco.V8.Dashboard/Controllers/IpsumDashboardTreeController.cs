using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace Umbraco.V8.Dashboard.Controllers
{
    [Tree("ipsumSection", "ipsumTreeAlias", TreeGroup = "ipsumsGroup" , SortOrder = 1)]
    [PluginController("Ipsums")]
    public class IpsumDashboardTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            // check if we're rendering the root node's children
            if (id == Constants.System.Root.ToInvariantString())
            {
                //hardcoding a set of ipsum nodes
                Dictionary<int, string> ipsums = new Dictionary<int, string>();
                ipsums.Add(1, "Bacon Ipsum");
                ipsums.Add(2, "Dino Ipsum");
               
                var nodes = new TreeNodeCollection();

                 foreach (var ipsum in ipsums)
                {
                    // add each node to the tree collection using the base CreateTreeNode method
                    //the code will look for a view in the App_Plugins/Ipsums/backoffice/ipsumTreeAlias
                    //the view name is set to be the node name with the space removed eg for Bacon Ipsum the view name will be baconipsum
                    var node = this.CreateTreeNode(ipsum.Key.ToString(), "-1", queryStrings, ipsum.Value,
                        "icon-presentation", false, 
                        routePath: string.Format("{0}/{1}/{2}", "ipsumSection", "ipsumTreeAlias", 
                            ipsum.Value.Replace(" ","")));
                    nodes.Add(node);
                }

                return nodes;
            }

            throw new NotSupportedException();
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
           //no actions for each menu item
            return null;
        }

        protected override TreeNode CreateRootNode(FormDataCollection queryStrings)
        {
            var root = base.CreateRootNode(queryStrings);

            //the code will look for a view in the App_Plugins/Ipsums/backoffice/ipsumTreeAlias
            root.RoutePath = string.Format("{0}/{1}/{2}", "ipsumSection", "ipsumTreeAlias", "overview");

            // set the icon
            root.Icon = "icon-hearts";
            // could be set to false for a custom tree with a single node.
            root.HasChildren = true;

            return root;
        }
    }
}