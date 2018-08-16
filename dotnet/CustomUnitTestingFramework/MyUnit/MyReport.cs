using System;
using System.Reflection;
using System.Text;

namespace MyUnit
{
    internal class MyReport
    {
        private Assembly assembly;
        private StringBuilder results = new StringBuilder();

        public MyReport(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public override string ToString()
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<!DOCTYPE html>");
            Builder.Append("<html>");
            Builder.Append("<body>");
            Builder.Append(string.Format("<h3 style='text-align:center;'>{0} - {1}</h3>", assembly.Location, assembly.GetName()));
            Builder.Append("<hr>");
            Builder.Append(results);
            Builder.Append("</hr>");
            Builder.Append("</body>");
            Builder.Append("</html>");
            return Builder.ToString();
        }

        internal void Append(MethodInfo methodInfo, Exception e = null)
        {
            if (e == null)
            {
                results.Append(string.Format("<p style='text-align:center; color:green;'>{0} - {1}</br>PASSED</p>", methodInfo.DeclaringType.Name, methodInfo.Name));
            }
            else
            {
                results.Append(string.Format("<p style='text-align:center; color:red;'>{0} - {1}</br>FAILED</br>{2}</p>", methodInfo.DeclaringType.Name, methodInfo.Name, e.ToString()));
            }
        }
    }
}
