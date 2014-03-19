using System;
using System.IO;

namespace ConfigTransformationTool
{
    public class OutputLog
    {
        readonly TextWriter outputStream;
        readonly TextWriter errorStream;

        OutputLog(TextWriter outputStream, TextWriter errorStream)
        {
            this.outputStream = outputStream;
            this.errorStream = errorStream;
        }

        public static OutputLog ErrorOnly(TextWriter errorStream)
        {
            if (errorStream == null)
            {
                throw new ArgumentNullException("errorStream");
            }

            return new OutputLog(null, errorStream);
        }

        public static OutputLog FromWriter(TextWriter writer, TextWriter errorStream)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            if (errorStream == null)
            {
                throw new ArgumentNullException("errorStream");
            }

            return new OutputLog(writer, errorStream);
        }

        public void WriteLine(string message, params object[] parameters)
        {
            if (this.outputStream != null)
            {
                this.outputStream.WriteLine(message, parameters);
            }
        }

        public void WriteErrorLine(string message, params object[] parameters)
        {
            if (this.errorStream != null)
            {
                this.errorStream.WriteLine(message, parameters);
            }
        }
    }
}