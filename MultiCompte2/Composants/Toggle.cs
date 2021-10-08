using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MultiCompte2.Composants
{
    class Toggle : Panel
    {
		public delegate void CheckedChangedEventHandler(object sender);

		[CompilerGenerated]
		private Color _FillColor;

		public bool onoff;

		private CheckedChangedEventHandler CheckedChangedEvent;

		internal StringFormat NearSF;

		private int x;

		private int y;

		private bool _Checked;

		private Point savePoint;

		private bool isDragging;

		private int mouseX;

		private int mouseY;

		public Color FillColor
		{
			get
			{
				return _FillColor;
			}
			set
			{
				_FillColor = value;
			}
		}

		[DisplayName("Onoff")]
		[PropertyTab("Onoff")]
		public bool Icons
		{
			get
			{
				return onoff;
			}
			set
			{
				onoff = value;
			}
		}

		[Category("Options")]
		public bool Checked
		{
			get
			{
				return _Checked;
			}
			set
			{
				_Checked = value;
			}
		}

		public event CheckedChangedEventHandler CheckedChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				CheckedChangedEvent = (CheckedChangedEventHandler)Delegate.Combine(CheckedChangedEvent, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				CheckedChangedEvent = (CheckedChangedEventHandler)Delegate.Remove(CheckedChangedEvent, value);
			}
		}

		public Toggle()
		{
			base.Resize += Theme_Resize;
			Color color2 = (FillColor = Color.FromArgb(27, 132, 188));
			onoff = false;
			NearSF = new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Near
			};
			_Checked = false;
			ref Point reference = ref savePoint;
			reference = new Point(0, 0);
			isDragging = false;
			SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
			DoubleBuffered = true;
			Size size2 = (Size = new Size(44, 18));
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(Width, Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			checked
			{
				if (onoff)
				{
					GraphicsPath path = RoundRec(0, 0, Width - 2, Height - 2, 14);
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.FillPath(new SolidBrush(FillColor), path);
					graphics.DrawPath(new Pen(FillColor), path);
					Pen pen = new Pen(Color.FromArgb(255, 255, 255));
					Rectangle rect = new Rectangle(Width - 17, Height - 17, 14, 14);
					graphics.DrawEllipse(pen, rect);
					SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
					rect = new Rectangle(Width - 17, Height - 17, 14, 14);
					graphics.FillEllipse(brush, rect);
					Font font = new Font("Wingdings", 14f);
					SolidBrush brush2 = new SolidBrush(Color.FromArgb(255, 255, 255));
					rect = new Rectangle(7, Height - 19, 14, 14);
					graphics.DrawString("ü", font, brush2, rect, NearSF);
				}
				else
				{
					GraphicsPath path2 = RoundRec(0, 0, Width - 2, Height - 2, 14);
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.FillPath(new SolidBrush(Color.FromArgb(184, 184, 184)), path2);
					graphics.DrawPath(new Pen(Color.FromArgb(184, 184, 184)), path2);
					Pen pen2 = new Pen(Color.FromArgb(255, 255, 255));
					Rectangle rect = new Rectangle(1, Height - 17, 14, 14);
					graphics.DrawEllipse(pen2, rect);
					SolidBrush brush3 = new SolidBrush(Color.FromArgb(255, 255, 255));
					rect = new Rectangle(1, Height - 17, 14, 14);
					graphics.FillEllipse(brush3, rect);
				}
				e.Graphics.DrawImage((Bitmap)bitmap.Clone(), 0, 0);
				graphics.Dispose();
				bitmap.Dispose();
				base.OnPaint(e);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			checked
			{
				Rectangle rectangle = new Rectangle(1, Height - 17, 14, 14);
				if (!onoff)
				{
					Point pt = new Point(e.X, e.Y);
					if (rectangle.Contains(pt))
					{
						onoff = true;
						CheckedChangedEvent?.Invoke(this);
					}
				}
				Rectangle rectangle2 = new Rectangle(Width - 17, Height - 17, 14, 14);
				if (onoff)
				{
					Point pt = new Point(e.X, e.Y);
					if (rectangle2.Contains(pt))
					{
						onoff = false;
						CheckedChangedEvent?.Invoke(this);
					}
				}
				base.OnMouseDown(e);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			isDragging = false;
			base.OnMouseUp(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			mouseX = e.X;
			mouseY = e.Y;
			base.OnMouseMove(e);
			Invalidate();
		}

		private void Theme_Resize(object sender, EventArgs e)
		{
			Refresh();
		}

		public GraphicsPath RoundRec(int X, int Y, int Width, int Height, int diameter)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
			PointF location = rectangleF.Location;
			SizeF size = new SizeF(diameter, diameter);
			RectangleF rect = new RectangleF(location, size);
			graphicsPath.AddArc(rect, 180f, 90f);
			checked
			{
				graphicsPath.AddLine(X + (int)Math.Round((double)diameter / 2.0), Y, X + Width - (int)Math.Round((double)diameter / 2.0), Y);
				rect.X = rectangleF.Right - (float)diameter;
				graphicsPath.AddArc(rect, 270f, 90f);
				graphicsPath.AddLine(X + Width, Y + (int)Math.Round((double)diameter / 2.0), X + Width, Y + Height - (int)Math.Round((double)diameter / 2.0));
				rect.Y = rectangleF.Bottom - (float)diameter;
				graphicsPath.AddArc(rect, 0f, 90f);
				graphicsPath.AddLine(X + (int)Math.Round((double)diameter / 2.0), Y + Height, X + Width - (int)Math.Round((double)diameter / 2.0), Y + Height);
				rect.X = rectangleF.Left;
				graphicsPath.AddArc(rect, 90f, 90f);
				graphicsPath.AddLine(X, Y + (int)Math.Round((double)diameter / 2.0), X, Y + Height - (int)Math.Round((double)diameter / 2.0));
				return graphicsPath;
			}
		}
	}
}
