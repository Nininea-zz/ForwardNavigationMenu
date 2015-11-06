using System;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Content.Res;
using System.Collections.Generic;
using Android.Graphics;
using Android.Views;
using Android.Graphics.Drawables;

namespace com.wandio
{
	[Register ("com.wandio.ForwardNavigationMenu")]
	public class ForwardNavigationMenu:ScrollView
	{
		#region Properties

		private int columnsInRow = 2;

		public int ColumnsInRow {
			get { return columnsInRow; }
			set {
				columnsInRow = value;
				Invalidate ();
			}
		}

		private Dictionary<int,int> columnsInRows;

		public Dictionary<int,int> ColumnsInRows {
			get { return columnsInRows; }
			set {
				columnsInRows = value;
				Invalidate ();
			}
		}


		private int elementCount = 2;

		public int ElementCount {
			get { return elementCount; }
			set {
				elementCount = value;
				Invalidate ();
			}
		}

		private int textSize = 10;

		public int TextSize {
			get { return textSize; }
			set {
				textSize = value;
				Invalidate ();
			}
		}

		private Color textColor;

		public Color TextColor {
			get { return textColor; }
			set {
				textColor = value;
			}
		}

		private Color itembgColor;

		public Color ItemBgColor {
			get { return itembgColor; }
			set {
				itembgColor = value;
			}
		}

		private int itemBg;

		public int ItemBg {
			get { return itemBg; }
			set {
				itemBg = value;
			}
		}

		private int dividerBg;

		public int DividerBg {
			get { return dividerBg; }
			set {
				dividerBg = value;
			}
		}

		private int dividerWidth = 0;

		public int DividerWidth {
			get { return dividerWidth; }
			set {
				dividerWidth = value;
			}
		}

		private int itemPadding = 0;

		public int ItemPadding {
			get { return itemPadding; }
			set {
				itemPadding = value;
			}
		}

		private int contentPadding = 0;

		public int ContentPadding {
			get { return contentPadding; }
			set {
				contentPadding = value;
			}
		}

		private int padding = 3;

		public int Padding {
			get { return padding; }
			set {
				padding = value;
			}
		}

		private int paddingLeft = 0;

		public int PaddingLeft {
			get { return paddingLeft; }
			set {
				paddingLeft = value;
			}
		}

		private int paddingRight = 0;

		public int PaddingRight {
			get { return paddingRight; }
			set {
				paddingRight = value;
			}
		}

		private int paddingTop = 0;

		public int PaddingTop {
			get { return paddingTop; }
			set {
				paddingTop = value;
			}
		}

		private int paddingBottom = 0;

		public int PaddingBottom {
			get { return paddingBottom; }
			set {
				paddingBottom = value;
			}
		}

		private int margin = 0;

		public int Margin {
			get { return margin; }
			set {
				margin = value;
			}
		}

		private int marginLeft = 0;

		public int MarginLeft {
			get { return marginLeft; }
			set {
				marginLeft = value;
			}
		}

		private int marginRight = 0;

		public int MarginRight {
			get { return marginRight; }
			set {
				marginRight = value;
			}
		}

		private int marginTop = 3;

		public int MarginTop {
			get { return marginTop; }
			set {
				marginTop = value;
			}
		}

		private int marginBottom = 3;

		public int MarginBottom {
			get { return marginBottom; }
			set {
				marginBottom = value;
			}
		}

		private int textAlpha = 150;

		public int TextAlpha {
			get { return textAlpha; }
			set { 
				textAlpha = value;
				Invalidate ();
			}
		}

		#endregion

		#region Values

		public EventHandler<int> ItemClicked;
		private LinearLayout _mainContainer;
		private Context _context;
		private TypefaceStyle typefaceStyle = TypefaceStyle.Normal;
		private Typeface tabTypeface = null;

		#endregion

		#region Setters

		public void SetTypeface (Typeface typeFace, TypefaceStyle style)
		{
			this.tabTypeface = typeFace;
			this.typefaceStyle = style;
		}

		#endregion

		#region Attributes

		private static int[] Attrs = new int[] {
			Android.Resource.Attribute.TextColorPrimary,
			Android.Resource.Attribute.TextSize, 
			Android.Resource.Attribute.TextColor,
			Android.Resource.Attribute.Padding,
			Android.Resource.Attribute.PaddingLeft,
			Android.Resource.Attribute.PaddingRight,
			Android.Resource.Attribute.PaddingTop,
			Android.Resource.Attribute.PaddingBottom,
			Android.Resource.Attribute.LayoutMargin,
			Android.Resource.Attribute.LayoutMarginLeft,
			Android.Resource.Attribute.LayoutMarginRight,
			Android.Resource.Attribute.LayoutMarginTop,
			Android.Resource.Attribute.LayoutMarginBottom

		};

		#endregion

		#region Ctor

		public ForwardNavigationMenu (Context context)
			: this (context, null)
		{
		}

		public ForwardNavigationMenu (Context context, IAttributeSet attrs)
			: this (context, attrs, 0)
		{
		}

		public ForwardNavigationMenu (Context context, IAttributeSet attrs, int defStyle)
			: base (context, attrs, defStyle)
		{
			_mainContainer = new LinearLayout (context);
			_mainContainer.Orientation = Android.Widget.Orientation.Vertical;
			_mainContainer.LayoutParameters = new LayoutParams (LayoutParams.MatchParent, LayoutParams.MatchParent);
			_context = context;

			var dm = Resources.DisplayMetrics;
			textSize = (int)TypedValue.ApplyDimension (ComplexUnitType.Sp, textSize, dm);

			var a = context.ObtainStyledAttributes (attrs, Attrs);

			a = context.ObtainStyledAttributes (attrs, Resource.Styleable.ForwardNavigationMenu);
			contentPadding = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmContentPadding, contentPadding);
			padding = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmPadding, padding);
			paddingLeft = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmPaddingLeft, paddingLeft);
			paddingBottom = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmPaddingBottom, paddingBottom);
			paddingRight = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmPaddingRight, paddingRight);
			paddingTop = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmPaddingTop, paddingTop);

			margin = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmMargin, margin);
			marginRight = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmMarginRight, marginRight);
			marginLeft = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmMarginLeft, marginLeft);
			marginBottom = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmMarginBottom, marginBottom);
			marginTop = a.GetDimensionPixelSize (Resource.Styleable.ForwardNavigationMenu_fnmMarginTop, marginTop);

			typefaceStyle = (TypefaceStyle)a.GetInt (Resource.Styleable.ForwardNavigationMenu_fnmTextStyle, (int)TypefaceStyle.Normal);
			textAlpha = a.GetInt (Resource.Styleable.ForwardNavigationMenu_fnmTextAlpha, textAlpha);
			a.Recycle ();

			_mainContainer.SetPadding (contentPadding, contentPadding, contentPadding, contentPadding);
			AddView (_mainContainer);
		}

		#endregion

		#region HelperMethods

		public void AddItems (List<MenuItem> Items)
		{
			if (ColumnsInRows == null) {
				GenerateItems (Items);
			} else {
				GenerateItemsByRows (Items);
			}
		}

		private void GenerateItems (List<MenuItem> Items)
		{
			try {
				var itemsCount = Items == null ? 0 : Items.Count;
				var layersCount = itemsCount / ColumnsInRow;
				if (itemsCount % ColumnsInRow > 0)
					layersCount++;

				for (int i = 0; i < layersCount; i++) {
					LinearLayout lt = new LinearLayout (_context);
					lt.Orientation = Android.Widget.Orientation.Horizontal;
					lt.LayoutParameters = new MarginLayoutParams (LayoutParams.MatchParent, LayoutParams.WrapContent);
				
					lt.WeightSum = ColumnsInRow;
					for (int j = i * ColumnsInRow; j < i * ColumnsInRow + ColumnsInRow; j++) {
						if (j >= itemsCount) {
							View emptyView = new View (_context);
							emptyView.LayoutParameters = new TableLayout.LayoutParams (0, LayoutParams.WrapContent, 1f);
							lt.AddView (emptyView);
						} else {
							var item = Items [j];
							lt.AddView (GenerateButton (item));
						}
					}
					_mainContainer.AddView (lt);
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
			}
		}

		private void GenerateItemsByRows (List<MenuItem> Items)
		{
			try {
				var index = 0;
				var itemsCount = Items == null ? 0 : Items.Count;
				var layersCount = ColumnsInRows.Count;

				for (int i = 0; i < layersCount; i++) {
					LinearLayout lt = new LinearLayout (_context);
					lt.Orientation = Android.Widget.Orientation.Horizontal;
					lt.LayoutParameters = new MarginLayoutParams (LayoutParams.MatchParent, LayoutParams.WrapContent);

					var columncount = ColumnsInRows [i];
					lt.WeightSum = columncount;

					for (int j = i * columncount; j < i * columncount + columncount; j++) {
						if (index >= itemsCount) {
							View emptyView = new View (_context);
							emptyView.LayoutParameters = new TableLayout.LayoutParams (0, LayoutParams.WrapContent, 1f);
							lt.AddView (emptyView);
						} else {
							var item = Items [index];
							lt.AddView (GenerateButton (item));
						}
						index++;
					}
					_mainContainer.AddView (lt);
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
			}
		}

		private Button GenerateButton (MenuItem item)
		{
			Button btn = new Button (_context);
			btn.Text = item.Text;

			var param = new TableLayout.LayoutParams (0, LayoutParams.WrapContent, 1f);
			if (margin >= 0) {
				marginBottom = marginLeft = marginTop = marginRight = margin;
			}
			param.BottomMargin = MarginBottom;
			param.LeftMargin = MarginLeft;
			param.TopMargin = MarginTop;
			param.RightMargin = MarginRight;

			btn.LayoutParameters = param;

			if (item.IconId != 0) {
				btn.SetCompoundDrawablesWithIntrinsicBounds (null, 
					Resources.GetDrawable (item.IconId),
					null, null);	
			}
			btn.SetTypeface (tabTypeface, typefaceStyle);
			btn.SetTextColor (TextColor);
			btn.TextSize = TextSize;
			btn.SetBackgroundColor (ItemBgColor);
			btn.SetBackgroundResource (ItemBg);
			if (padding != 0) {
				paddingLeft = paddingTop = paddingRight = paddingBottom = padding;
			}
			btn.SetPadding (paddingLeft, paddingTop, paddingRight, paddingBottom);
			btn.Click += (o, e) => {
				if (ItemClicked != null) {
					ItemClicked (this, item.ItemId);
				}
			};
			return btn;
		}

		private ColorStateList GetColorStateList (int textColor)
		{
			return new ColorStateList (new int[][]{ new int[]{ } }, new int[]{ textColor });
		}

		#endregion
	}

	#region MenuItem
	public class MenuItem
	{
		public int ItemId  { get; set; }

		public int IconId  { get; set; }

		public string Text  { get; set; }
	}
	#endregion
}

