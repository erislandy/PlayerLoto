﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerLoto.Mobile.ModelsUI
{
    public class Option
    {

        #region Properties
      
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetPage { get; set; }

        public string Letter
        {
            get
            {
                return Name.Substring(0, 1);
            }

        }
        #endregion





    }

}
