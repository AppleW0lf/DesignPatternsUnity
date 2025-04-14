using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.Test2
{
    public interface IPlayerState
    {
        void EnterState(PlayerController player);

        void UpdateState(PlayerController player);

        void ExitState(PlayerController player);
    }
}