using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PoleStat.UI
{
	internal partial class MainWindow : Form
	{
		private DisplayMessage _activeDisplayMessage;

		public static MainWindow Instance { get; private set; }

		public DisplayMessage ActiveDisplayMessage
		{
			get { return _activeDisplayMessage; }
			set
			{
				if (InvokeRequired)
				{
					Invoke(new Action(() => ActiveDisplayMessage = value));
					return;
				}

				_activeDisplayMessage = value;
				
				tbActiveMessageTopLine.Text = _activeDisplayMessage.TopLine;
				tbActiveMessageBottomLine.Text = _activeDisplayMessage.BottomLine;
			}
		}

		public MainWindow()
		{
			InitializeComponent();

			Instance = this;

			var menu = new ContextMenu();
			menu.MenuItems.Add(new MenuItem("Open", (sender, args) => Show()));
			menu.MenuItems.Add(new MenuItem("Exit", ExitApp));

			niTrayIcon.ContextMenu = menu;
		}

		public void ExitApp(object sender, EventArgs e)
		{
			DisplayManager.Clear();

			Application.Exit();
			Environment.Exit(1);
		}

		public void UpdateStatisticPages(IEnumerable<IStatisticsPage> pages)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => UpdateStatisticPages(pages)));
				return;
			}

			lbPages.Items.Clear();

			foreach (var statisticsPage in pages)
			{
				lbPages.Items.Add(statisticsPage.ToString());
			}
		}

		public void SetActivePage(IStatisticsPage page)
		{
			if (InvokeRequired)
			{
				Invoke(new Action(() => SetActivePage(page)));
				return;
			}

			string name = page.ToString();

			lbPages.SelectedItem = name;
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}
	}
}
