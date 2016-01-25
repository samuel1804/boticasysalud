using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using SIGCOMT.Persistence;

namespace SIGCOMT.Aspects
{
    [Serializable]
    public sealed class CommitsOperationAttribute : MethodInterceptionAspect
    {
        public CommitsOperationAttribute()
        {
            AspectPriority = 10;
            AttributePriority = 10;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            MessageDispatcher _dispatcher = new MessageDispatcher();

            if (args.ReturnValue == null)
                _dispatcher.HandleCommand(args.Proceed);
        }
    }
}
