using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectAPI.game
{
    public class News
    {
        private string _Title;
        private string _Content;
        private DateTime _DateCreated;

        public News()
        {

        }

        public string Title
        {
            get => this._Title;
            set => this._Title = value;
        }

        public string Content
        {
            get => this._Content;
            set => this._Content = value;
        }

        public DateTime DateCreated
        {
            get => this._DateCreated;
            set => this._DateCreated = value;
        }
    }
}
