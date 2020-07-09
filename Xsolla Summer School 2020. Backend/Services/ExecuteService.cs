using Common.Enums;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Xsolla_Summer_School_2020._Backend.Infrastructure;

namespace Xsolla_Summer_School_2020._Backend.Services
{
    /// <summary>
    /// Вспомогательный класс, который позволяет централизовано перехыватывать ошибки и оборачивать их
    /// в корректный ответ <see cref="ServiceResponse{T}"/>
    /// </summary>
    public sealed class ExecuteService
    {
        /// <summary>
        /// Выполнить какое либо действие и обернуть резудьтат в <see cref="ServiceResponse{T}"/>
        /// </summary>
        /// <param name="action"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <exception cref="HttpResponseException"></exception>
        public async Task<ServiceResponse<TResult>> TryExecute<TResult>(Func<Task<TResult>> action)
        {
            var result = new ServiceResponse<TResult>();
            try
            {
                TResult content = await action();

                result.Content = content;
                result.ResponseInfo.Status = ResponseStatus.Success;

                return result;
            }
            catch (ValidationException e)
            {
                result.ResponseInfo.Status = ResponseStatus.ValidationError;
                result.ResponseInfo.ErrorMessage = e.Message;
                result.ResponseInfo.ValidationErrors = e.ErrorsList;
                result.ResponseInfo.ErrorCode = ErrorCode.FailedValidation;

                return result;
            }

            catch (HttpResponseException e)
            {
                result.ResponseInfo.Status = ResponseStatus.ValidationError;
                result.ResponseInfo.ErrorMessage = e.Message;
                result.ResponseInfo.ErrorCode = ErrorCode.FailedValidation;

                return result;
            }

            catch (Exception e)
            {
                result.ResponseInfo.Status = ResponseStatus.Error;
                result.ResponseInfo.ErrorMessage = e.Message;
                result.ResponseInfo.ErrorCode = ErrorCode.Unclassified;

                return result;
            }
        }
    }
}
