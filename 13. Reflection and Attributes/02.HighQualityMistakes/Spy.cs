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

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] classFields = classType.GetFields
                (BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static);

            MethodInfo[] publicMethods = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.Public);

            MethodInfo[] privateMethods  = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            } 
            foreach (MethodInfo getter in privateMethods)
            {
                if (getter.Name.StartsWith("get"))
                {
                    stringBuilder.AppendLine($"{getter.Name} have to be public!");
                }
            } 
            foreach (MethodInfo setter in publicMethods)
            {
                if (setter.Name.StartsWith("set"))
                {
                    stringBuilder.AppendLine($"{setter.Name} have to be private!");
                }
            }

            return stringBuilder.ToString().Trim();

        }
    }
}
