using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class LocationFeature
    {
        public bool isResolved;
        public bool lostGame;
        public bool noResolve;

        protected LocationFeature(bool isResolved)
        {
            this.isResolved = isResolved;
            this.lostGame = false;
            this.noResolve = false;
        }

        public abstract void Resolve();
    }
}
