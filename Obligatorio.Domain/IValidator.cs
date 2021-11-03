namespace Obligatorio.Domain
{
    public interface IValidator<T>
    {
        (bool,string errorMessage) Validate(T Model);
    }
}