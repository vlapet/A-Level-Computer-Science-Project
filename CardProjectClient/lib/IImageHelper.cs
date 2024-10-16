using CardProjectClient.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.lib
{
    interface IImageHelper
    {
        void SetImageProperties(int WhichImageData, Card CurrentCard);
    }

    interface IImageCore
    {
        void SetImageProperties(Card CurrentCard);
    }

    interface IImageHelperExtensions
    {
        void SetImageProperties(int WhichImageData, string CardName, string CardID, string CardRarity, string CardFrame, string CardNickname);
    }
}
