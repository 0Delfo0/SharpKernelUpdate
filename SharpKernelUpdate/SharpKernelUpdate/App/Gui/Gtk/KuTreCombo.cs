using Gtk;
using SharpKernelUpdate.App.Model;
using SharpKernelUpdate.App.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpKernelUpdate.App.Gui.Gtk
{
    internal class KuTreCombo
    {
        private readonly HBox _hBoxCombo = new HBox(false, 5);
        private ProgressBar _progressBar;
        private readonly List<KuUrlItem> _mainList;
        private IEnumerable<IGrouping<string, KuUrlItem>> _groupingList;
        private List<KuUrlItem> _currentList = new List<KuUrlItem>();

        private int _comboIndex = 0;

        public KuTreCombo(ProgressBar progressBar)
        {
            _progressBar = progressBar;
            _mainList = KuParser.GetMainList(progressBar);
        }

        public Widget Create()
        {
            Create(_mainList);
            _hBoxCombo.Show();
            return _hBoxCombo;
        }

        public Widget GetWidget()
        {
            return _hBoxCombo;
        }

        private void Create(IEnumerable<KuUrlItem> urlItemList)
        {
            var groupingList = KuFilter.GetListElements(_comboIndex, urlItemList);
            _groupingList = groupingList;

            var cb = new ComboBox(groupingList.Select(i => i.Key).ToArray());
            cb.Changed += MainComboBox_Changed;
            _hBoxCombo.PackStart(cb, false, false, 1);
            cb.Show();
        }

        private void MainComboBox_Changed(object sender, EventArgs e)
        {
            var cb = (ComboBox) sender;
            var index = cb.Active;

            var element = _groupingList.ElementAt(index);

            _comboIndex++;
            Create(element.ToList());
        }
    }
}