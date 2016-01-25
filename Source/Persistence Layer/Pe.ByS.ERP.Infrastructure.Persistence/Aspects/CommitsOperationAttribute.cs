using System;
using PostSharp.Aspects;

namespace Pe.ByS.ERP.Infrastructure.Persistence.Aspects
{
    [Serializable]
    public sealed class CommitsOperationAttribute : MethodInterceptionAspect
    {
        public bool SaveLogGeneral { get; set; }
        public int TablaId { get; set; }
        public int TipoAccionId { get; set; }
        public int UsuarioId { get; set; }

        public CommitsOperationAttribute()
        {
            AspectPriority = 10;
            AttributePriority = 10;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var dispatcher = new MessageDispatcher();

            if (args.ReturnValue == null)
                dispatcher.HandleCommand(args.Proceed);
        }
    }
}
