using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using ExceptionHandling_T1.Core.ExceptionHandling;

namespace ExceptionHandling_T1
{
    public class MyProxy : RealProxy
    {
        private MarshalByRefObject _myMarshalByRefObject;

        public MyProxy(Type baseType)
            : base(baseType)
        {
            _myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance((baseType));

        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;

            var tr = methodCall.MethodBase.GetCustomAttributes(typeof(ExceptionHandlingAttribute), true).First() as ExceptionHandlingAttribute;

            IMethodReturnMessage methodReturnMessage = null;
            try
            {
                methodReturnMessage = methodCall?.MethodBase.Invoke(_myMarshalByRefObject, methodCall.Args) as IMethodReturnMessage;
            }
            catch (Exception exception)
            {
                tr.Execute(exception.InnerException);
                return new ReturnMessage(exception, msg as IMethodCallMessage);
                //tr.HandleException(methodReturnMessage.LogicalCallContext.);

            }

            return methodReturnMessage;
        }
    }
}
