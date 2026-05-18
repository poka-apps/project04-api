using Project04.Domain.Enums;

namespace Project04.Domain
{
    public class AppException : System.ComponentModel.DataAnnotations.ValidationException
    {
        public AppErrorEnums ErrorCode { get; private set; } = AppErrorEnums.Unknow;

        public AppException(string? message = null)
            : base(message)
        {
        }

        public AppException(AppErrorEnums codeError)
            : base(codeError.GetDescription())
        {
            this.ErrorCode = codeError;
        }

        public AppException(AppErrorEnums codeError, Exception cause, params object[] data)
                   : base(codeError.GetDescription(), cause)
        {
            this.ErrorCode = codeError;

            for (int index = 0; index < data.Length; index++)
            {
                this.Data.Add(index.ToString(), data[index]);
            }
        }

        public AppException(AppErrorEnums codeError, params object[] data)
            : base(codeError.GetDescription())
        {
            this.ErrorCode = codeError;

            for (int index = 0; index < data.Length; index++)
            {
                this.Data.Add(index.ToString(), data[index]);
            }
        }

        public AppException(string message, AppErrorEnums codeError)
            : base(message)
        {
            this.ErrorCode = codeError;
        }

        public AppException(string message, AppErrorEnums codeError, params object[] data)
            : base(message)
        {
            this.ErrorCode = codeError;

            for (int index = 0; index < data.Length; index++)
            {
                this.Data.Add(index.ToString(), data[index]);
            }
        }
    }
}
