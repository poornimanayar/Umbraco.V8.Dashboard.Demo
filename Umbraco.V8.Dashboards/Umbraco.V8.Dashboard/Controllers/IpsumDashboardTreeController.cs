using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace Umbraco.V8.Dashboard.Controllers
{
    [Tree("ipsumSection", "ipsumTreeAlias", TreeTitle = "Ipsums", TreeGroup = "ipsumsGroup", SortOrder = 5)]
    [PluginController("Ipsums")]
    public class IpsumDashboardTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            // check if we're rendering the root node's children
            if (id == Constants.System.Root.ToInvariantString())
            {
                // you can get your custom nodes from anywhere, and they can represent anything...
                Dictionary<int, string> ipsums = new Dictionary<int, string>();
                ipsums.Add(1, "Bacon");
                ipsums.Add(2, "Dino");
                // create our node collection
                var nodes = new TreeNodeCollection();

                // loop through our favourite things and create a tree item for each one
                foreach (var ipsum in ipsums)
                {
                    // add each node to the tree collection using the base CreateTreeNode method
                    // it has several overloads, using here unique Id of tree item, -1 is the Id of the parent node to create, eg the root of this tree is -1 by convention - the querystring collection passed into this route - the name of the tree node -  css class of icon to display for the node - and whether the item has child nodes
                    var node = this.CreateTreeNode(ipsum.Key.ToString(), "-1", queryStrings, ipsum.Value,"icon-presentation", false, routePath: string.Format("{0}/{1}/{2}", "ipsumSection", "ipsumTreeAlias", ipsum.Value));
                    nodes.Add(node);
                }

                return nodes;
            }

            // this tree doesn't support rendering more than 1 level
            throw new NotSupportedException();
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            // create a Menu Item Collection to return so people can interact with the nodes in your tree
            var menu = new MenuItemCollection();

            if (id == Constants.System.Root.ToInvariantString())
            {
                // root actions, perhaps users can create new items in this tree, or perhaps it's not a content tree, it might be a read only tree, or each node item might represent something entirely different...
                // add your menu item actions or custom ActionMenuItems
                menu.Items.Add(new CreateChildEntity(this.Services.TextService));
                // add refresh menu item (note no dialog)
                menu.Items.Add(new RefreshNode(this.Services.TextService, true));
                return menu;
            }

            return menu;
        }

        protected override TreeNode CreateRootNode(FormDataCollection queryStrings)
        {
            var root = base.CreateRootNode(queryStrings);
            //optionally setting a routepath would allow you to load in a custom UI instead of the usual behaviour for a tree
            root.RoutePath = string.Format("{0}/{1}/{2}", "ipsumSection", "ipsumTreeAlias", "overview");

            // set the icon
            root.Icon = "icon-hearts";
            // could be set to false for a custom tree with a single node.
            root.HasChildren = true;
            //url for menu
            root.MenuUrl = null;

            return root;
        }
    }
}