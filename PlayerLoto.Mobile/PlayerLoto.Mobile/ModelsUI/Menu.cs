using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerLoto.Mobile.ModelsUI
{
    public class Menu
    {
        #region Properties
        public string Letter
        {
            get
            {
                return Title.Substring(0, 1);
            }

        }
        public string Title
        {
            get; set;
           
        }
        public string TargetPage { get; set; }

        #endregion

    }
}
