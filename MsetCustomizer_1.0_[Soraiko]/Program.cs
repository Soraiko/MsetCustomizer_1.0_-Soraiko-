using System;
using System.Windows.Forms;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm : Form
	{
		const string Auteur = "Soraiko";
		const string Version = "9.0";
		const string AppName = "KH2MsetCustomizer";
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.AddMessageFilter(new MouseMessageFilter());
			Application.Run(new MainForm());
		}
	}

	public partial class MouseMessageFilter : IMessageFilter
	{
		public static event MouseEventHandler MouseMove = delegate {};
		const int WM_MOUSEMOVE = 0x0200;

		public bool PreFilterMessage(ref Message m) {

			if (m.Msg == WM_MOUSEMOVE) {

				System.Drawing.Point mousePosition = Control.MousePosition;

				MouseMove(null, new MouseEventArgs(
					MouseButtons.None, 0, mousePosition.X, mousePosition.Y,0));
			}
			return false;
		}
	}
}
