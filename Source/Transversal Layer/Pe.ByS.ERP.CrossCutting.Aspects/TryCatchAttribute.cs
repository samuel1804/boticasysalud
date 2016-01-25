using System;
using System.Reflection;
using log4net;
using Pe.ByS.ERP.CrossCutting.Common;
using PostSharp.Aspects;

namespace Pe.ByS.ERP.CrossCutting.Aspects
{
    [Serializable]
    public sealed class TryCatchAttribute : OnMethodBoundaryAspect
    {
        public bool RethrowException { get; set; }
        public Type ExceptionTypeExpected { get; set; }

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TryCatchAttribute()
        {
            AspectPriority = 9;
            AttributePriority = 9;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            //if (args.Exception.GetType() == ExceptionTypeExpected)
            //{
                //Log.Error(args.Exception.Message, args.Exception);
                Log.Error(UtilsComun.GetExceptionMessage(args.Exception), args.Exception);
                args.FlowBehavior = RethrowException ? FlowBehavior.RethrowException : FlowBehavior.Continue;
            //}
        }
    }
}