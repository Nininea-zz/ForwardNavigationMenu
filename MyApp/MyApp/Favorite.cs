
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using com.wandio;

namespace MyApp
{
	[Activity (Label = "Favorite")]			
	public class Favorite : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.ContentView);
			InitData ();
		}

		void InitData ()
		{
			var menu = FindViewById<ForwardNavigationMenu> (Resource.Id.menu);
			List<MenuItem> items = new List<MenuItem> ();
			menu.TextColor = Resources.GetColor (Resource.Color.TextColor);
			menu.ColumnsInRow = 2;
			menu.TextSize = 12;
			menu.ItemBg = Resource.Drawable.itembg;
			menu.ColumnsInRows = new Dictionary<int, int> ();
			menu.ColumnsInRows.Add (0, 1);
			menu.ColumnsInRows.Add (1, 1);
			menu.ColumnsInRows.Add (2, 3);
			menu.ColumnsInRows.Add (3, 1);

			items.Add (new MenuItem {
				IconId = Resource.Drawable.note,
				ItemId = 1,
				Text = Resources.GetString (Resource.String.note)
			});
			items.Add (new MenuItem {
				IconId = Resource.Drawable.pin,
				ItemId = 1,
				Text = Resources.GetString (Resource.String.places)
			});
			items.Add (new MenuItem {
				IconId = Resource.Drawable.fav,
				ItemId = 1,
				Text = Resources.GetString (Resource.String.fav)
			});
			items.Add (new MenuItem {
				IconId = Resource.Drawable.speed,
				ItemId = 1,
				Text = Resources.GetString (Resource.String.speed)
			});
			items.Add (new MenuItem {
				IconId = Resource.Drawable.speed,
				ItemId = 1,
				Text = Resources.GetString (Resource.String.speed)
			});
			items.Add (new MenuItem {
				IconId = Resource.Drawable.speed,
				ItemId = 1,
				Text = Resources.GetString (Resource.String.speed)
			});
			menu.AddItems (items);
		}
	}
}

