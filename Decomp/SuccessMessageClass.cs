using System;
using System.Linq;
using System.Runtime.CompilerServices;

public sealed class CodeGenerator
{
    public static string GenerateRandomCode(int length)
    {
        return new string(Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length).Select(new Func<string, char>(RandomCharSelector.Instance.GetRandomChar)).ToArray<char>());
    }

    private static Random _random = new Random();

    [Serializable]
    private sealed class RandomCharSelector
    {
        public static readonly RandomCharSelector Instance = new RandomCharSelector();

        public char GetRandomChar(string source)
        {
            return source[_random.Next(source.Length)];
        }

        public static Func<string, char> DelegateInstance;
    }

    public sealed class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public sealed class KeyValuePairData
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public sealed class WeeklyDataResponse
    {
        public WeeklyDataResponse()
        {
            Success = true;
            Message = "WeeklyData";
            WeeklyData = new Challenge.WeeklyData();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public Challenge.WeeklyData WeeklyData { get; set; }
    }
}
