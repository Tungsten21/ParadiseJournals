using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Items
{
    public class NoteViewModel
    {

		private string _title;
        private string _text;
        private ObservableCollection<string> _additionalPhotos;

        public string Title
		{
			get { return _title; }
			set { _title = value; }
		}


		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}


		public ObservableCollection<string> AdditionalPhotos
        {
			get { return _additionalPhotos; }
			set { _additionalPhotos = value; }
		}



	}
}
