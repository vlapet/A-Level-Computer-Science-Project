using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.lib
{
    public static class Globals
    {
        private static string _APIEndpoint;

        #region Accessor methods

        public static string APIEndpoint
        {
            get => _APIEndpoint;
            set => _APIEndpoint = value;
        }

        #endregion
    }
}
