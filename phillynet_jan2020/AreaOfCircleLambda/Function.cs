using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AreaOfCircleLambda
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            // return input?.ToUpper();
            
            //
            //    conversion code
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(input);
            }

            int.TryParse(input, out var radius);
            var area = Math.PI * Math.Pow(radius, 2);
            return area.ToString(CultureInfo.InvariantCulture);
        }
    }
}
