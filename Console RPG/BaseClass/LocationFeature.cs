using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class LocationFeature
    {
        public bool isResolved;

        public LocationFeature(bool isResolved)
        {
            this.isResolved = isResolved;
        }

        public abstract void Resolve();
    }
}
