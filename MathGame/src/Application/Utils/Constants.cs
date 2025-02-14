namespace MathGame.src.Application.Utils;

public static class Constants
{
    #region sqlite
    public const string DatabaseFilename = "MathGameDB.db3";
    public static readonly string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    #endregion
    #region navigation
    public const string ToPlayground = "playground";
    public const string ToSignIn = "sign-in";
    public const string ToSignUp = "sign-up";
    #endregion
}
