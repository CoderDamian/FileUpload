namespace FileValidation
{
    public record Result(bool Acceptable, Status Status, string Message);

    public enum Status { GENUINE, FAKE, NOT_SUPPORTED, SIZE_EXCEEDED };
}
