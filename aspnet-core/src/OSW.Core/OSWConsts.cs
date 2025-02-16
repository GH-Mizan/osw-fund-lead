using OSW.Debugging;

namespace OSW;

public class OSWConsts
{
    public const string LocalizationSourceName = "OSW";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ba91cbe7f4ed4c3282831247f1acfe37";
}
