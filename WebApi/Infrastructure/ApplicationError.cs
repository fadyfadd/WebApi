namespace Infrastructure.WebApi;

public class ApplicationError : ApplicationException {
    public ApplicationError() {

    }

    public ApplicationError(String message): base(message) {

    }

    public ApplicationError(String message , Exception exception) : base(message , exception) {

    }
}
