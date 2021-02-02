using Stealer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] requestedFields)
        {
            Type type = Type.GetType(nameOfClass);
  

            FieldInfo[] classFields = type.GetFields
                (BindingFlags.NonPublic|BindingFlags.Instance|
                BindingFlags.Static|BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

             Object classInstance = Activator.CreateInstance
                (type, new object[] { });

            sb.AppendLine($"Class under investigation: {type}");

            foreach (var field in classFields)
            {
               if(requestedFields.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] methods = classType.GetMethods
                (BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();

            foreach (var classMethod in methods)
            {
                if(classMethod.Name.StartsWith("get"))
                {
                    sb.AppendLine
                        ($"{classMethod.Name} will return {classMethod.ReturnType}");
                }
            }
            foreach (var classMethod in methods)
            {
                if(classMethod.Name.StartsWith("set"))
                { 
                    sb.AppendLine
                       ($"{classMethod.Name} will set field of {classMethod.GetParameters().First().ParameterType}");
                }
            }
            return sb.ToString().Trim();
        }
    }
}
