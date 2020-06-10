using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GalacticPuffin
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//test();
		}
		private void test()
		{
			//TakeBetween("aa", "", "", false);
			//GraduatedValue(1500, 0, false);
			RunTests();
		}
		

		public static void RunTests()
		{
			//Build a test tree (matches the example)
			CustomNode root = new CustomNode("Root", null);
			CustomNode userData = new CustomNode("UserData", root);
			CustomNode ud_browser = new CustomNode("Browser", userData);
			CustomNode ud_word = new CustomNode("Word", userData);
			CustomNode priv = new CustomNode("Private", userData);
			CustomNode priv_word = new CustomNode("Word", priv);

			CustomNode windows = new CustomNode("Windows", root);
			CustomNode programs = new CustomNode("Programs", root);
			CustomNode notepad = new CustomNode("Notepad", programs);
			CustomNode prog_word = new CustomNode("Word", programs);
			CustomNode prog_browser = new CustomNode("Browser", programs);

			CustomNode custom1 = new CustomNode("Root", root);
			CustomNode custom2 = new CustomNode("UserData", custom1);
			CustomNode custom3 = new CustomNode("Word", custom2);



			CustomNode target = root.Find("Root/UserData/Word");
			
			

			var v=(GetShortestUniqueQualifier(root, target));
		}


		public static string GetShortestUniqueQualifier(CustomNode root, CustomNode target)
		{

			var path0 = target.Title;
			target.Title = "checked";
			//root.Find(path).Title="";
			var v0 = root.Any(path0, root, "");
			if (v0 == null||v0=="")
				return path0;
			else
			{


				// other place have notepad, 
				var parent = target.Parent;
				if (parent == null)
					return path0;
				var path = parent.Title + '/' + path0;
				parent.Title = "checked";
				//root.Find(path).Title="";
				var v1 = root.Any(path, root, "");
				if (v1 == null||v1=="")
					return path;
				else
				{
					var parent1 = parent.Parent;
					var path1 = parent1.Title + '/' + path;
					parent1.Title = "checked";
					//root.Find(path).Title="";
					var v2 = root.Any(path1, root, "");
					if (v2 == null||v2=="")
						return path1;
				}
			}
			// ohte rplace have vPrograms/notepad, go parent.



			//var v2=root.Find(target.Title);

			return target.Title;
		}
	}
}
public class CustomNode
{
	public string Title;
	public CustomNode Parent;
	public List<CustomNode> Children;

	public CustomNode(string title, CustomNode parent)
	{
		Title = title;
		Parent = parent;
		Children = new List<CustomNode>();

		if (Parent != null)
			Parent.Children.Add(this);
	}

	public CustomNode Find(string path)
	{
		if (path == Title)
			return this;

		string[] pieces = path.Split(new char[] { '/' });

		foreach (var child in Children)
		{
			if (child.Title == pieces[1])
				return child.Find(path.Remove(0, Title.Length + 1));
		}
		return null;
	}

	public string Any(string path, CustomNode root, string matchpath)
	{
		

		string[] pieces = path.Split(new char[] { '/' });
		if (pieces[pieces.Length-1] == Title)
		{
			return pieces[pieces.Length - 1];
		}
		foreach (var child in root.Children)
		{
			var v = child.Any(path, child,  matchpath);
			if (v == "")
			{
				// no match
				continue;
			}
			else
			{
				if (matchpath == "")

					matchpath = v;
				else
					matchpath = v + "/" + matchpath;

				path = path.Replace(v, "");
				if (path.EndsWith("/"))
					path=path.Remove(path.Length - 1);

				if (path == "")
					return matchpath;
				else
				{
					var vcheck = ParentAny(path, child.Parent, matchpath);
					if (vcheck == "")
						continue;
					else
						return vcheck;
				}
			}
			//if (child.Title == pieces[0])
			//{
			//	matchpath = child.Title + '/' + matchpath;
			//	//string pathnew = path.Substring(path.IndexOf('/'));
			//	return child.Any(path.Remove(0, Title.Length + 1), root, ref i, matchpath);
			//}
				
		}

		return "";
	}

	public string ParentAny(string path, CustomNode root,  string matchpath)
	{


		string[] pieces = path.Split(new char[] { '/' });
		if (pieces[pieces.Length - 1] == Title)
		{
			if (matchpath == "")

				matchpath = Title;
			else
				matchpath = Title + "/" + matchpath;
			
			path = path.Replace(Title, "");
			if (path == "")
				return matchpath;
			else
			{
				return ParentAny(path, root.Parent,  matchpath);
			}
		}
		return "";
	

	
	}
}


