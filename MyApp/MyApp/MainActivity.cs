
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
using Android.Graphics;

namespace MyApp
{
	[Activity (Label = "My App", MainLauncher = true)]			
	public class MainActivity : Activity
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

			items.Add (new MenuItem {
				IconId = Resource.Drawable.note,
				ItemId = 1,
				Text = Resources.GetString (Resource.String.note)
			});
			items.Add (new MenuItem {
				IconId = Resource.Drawable.pin,
				ItemId = 2,
				Text = Resources.GetString (Resource.String.places)
			});
			items.Add (new MenuItem {
				IconId = Resource.Drawable.fav,
				ItemId = 3,
				Text = Resources.GetString (Resource.String.fav)
			});
			items.Add (new MenuItem {
				IconId = Resource.Drawable.speed,
				ItemId = 4,
				Text = Resources.GetString (Resource.String.speed)
			});
			menu.ItemClicked += (o, e) => {
				switch (e) {
				case 1:
					StartActivity (typeof(Notes));
					break;
				case 3:
					StartActivity (typeof(Favorite));
					break;
				default :
					break;
				}
			};
			menu.AddItems (items);
		}
	}
}

