using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectAPI.game
{
    public class CardProperties
    {
        private string? _CardNickname;
        private string? _CardRarity;
        private string? _CardFrame;

        #region Constructors

        public CardProperties()
        {

        }

        public CardProperties(string CardNickname, string CardRarity, string CardFrame)
        {
            this._CardNickname = CardNickname;
            this._CardRarity = CardRarity;
            this._CardFrame = CardFrame;
        }

        #endregion

        #region Private Accessors

        public string? CardNickname
        {
            get => this._CardNickname;
            set => this._CardNickname = value;
        }

        public string? CardRarity
        {
            get => _CardRarity;
            set => _CardRarity = value;
        }

        public string? CardFrame
        {
            get => _CardFrame;
            set => _CardFrame = value;
        }

        #endregion
    }
}
