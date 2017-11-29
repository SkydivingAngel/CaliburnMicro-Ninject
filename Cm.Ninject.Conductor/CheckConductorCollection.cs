using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Cm.Ninject.Conductor
{
    class CheckConductorCollection
    {
        public static bool AlreadyOpened(Conductor<IScreen>.Collection.OneActive conductorCollection, string name)
        {
            return conductorCollection.GetChildren().Any(x => x.DisplayName == name);
        }
    }
}
