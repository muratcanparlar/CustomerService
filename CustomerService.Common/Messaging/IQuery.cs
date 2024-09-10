using MediatR;

namespace CustomerService.Common.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;