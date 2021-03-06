﻿namespace GE.WebUI.ViewModels
{
    public sealed class VMLGNB
    {
        /// <summary>
        /// default counstructor
        /// </summary>
        /// <param name="lnc">last news count</param>
        /// <param name="gc">games count</param>
        public VMLGNB(int lnc, int gc, int glnc) {
            News = new VMLGNBNews[lnc];
            Games = new VMLGNBGame[gc];
        }

        public VMLGNBNews[] News { get; set; }
        public VMLGNBGame[] Games { get; set; }
    }
}