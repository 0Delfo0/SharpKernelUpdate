using Gtk;
using SharpKernelUpdate.App.Model;
using SharpKernelUpdate.App.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpKernelUpdate.App.Gui.Gtk
{
    class KUTreCombo
    {
        HBox _hBox_Combo = new HBox(false, 5);

        List<KUUrlItem> _mainList = KUParser.GetMainList();
        IEnumerable<IGrouping<string, KUUrlItem>> _groupingList;
        List<KUUrlItem> _currentList = new List<KUUrlItem>();

        int _COMBO_INDEX = 0;

        public Widget Create()
        {
            Create(_mainList);
            _hBox_Combo.Show();
            return _hBox_Combo;
        }

        public Widget GetWidget()
        {
            return _hBox_Combo;
        }

        void Create(List<KUUrlItem> urlItemList)
        {
            var groupingList = KUFilter.GetListElements(_COMBO_INDEX, urlItemList);
            _groupingList = groupingList;

            List<string> values = new List<string>();

            foreach (var i in groupingList)
            {
                values.Add(i.Key);
            }

            var cb = new ComboBox(values.ToArray());
            cb.Changed += MainComboBox_Changed;
            _hBox_Combo.PackStart(cb, false, false, 1);
            cb.Show();
        }

        void MainComboBox_Changed(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int index = cb.Active;

            var element = _groupingList.ElementAt(index);

            _COMBO_INDEX++;
            Create(element.ToList());
        }
    }
}
