using Gtk;
using SharpKernelUpdate.App.Model;
using SharpKernelUpdate.App.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernelUpdate.App.Gui.GTK
{
    class TreCombo
    {
        static HBox _hBox_Combo = new HBox(false, 5);

        List<UrlItem> _mainList = Parser.GetMainList();
        IEnumerable<IGrouping<string, UrlItem>> _groupingList;
        List<UrlItem> _currentList = new List<UrlItem>();

        int _COMBO_INDEX = 0;

        public Widget Create()
        {
            Create(_mainList);
            return _hBox_Combo;
        }


        void Create(List<UrlItem> urlItemList)
        {
            _groupingList = Filter.GetListElements(_COMBO_INDEX, urlItemList);

            var children = _hBox_Combo.Children;
            foreach (var child in _hBox_Combo.Children)
            {
                child.Destroy();
            }

            List<string> values = new List<string>();

            foreach (var i in _groupingList)
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
            var tmpList = element.ToList();

            _COMBO_INDEX++;
            Create(element.ToList());
        }

        

    }


}
