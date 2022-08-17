using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeandroExhumed.SpaceChaos.Common
{
    public class ShooterModel
    {
        public event Action OnShot;

        public void Shot ()
        {
            OnShot?.Invoke();
        }
    }
}
