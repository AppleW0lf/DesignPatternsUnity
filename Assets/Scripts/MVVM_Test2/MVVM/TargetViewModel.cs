using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MVVM_Test2.MVVM
{
    public class TargetViewModel
    {
        public TargetModel TargetModel { get; }

        public TargetViewModel(TargetModel targetModel)
        {
            TargetModel = targetModel;
        }
    }
}