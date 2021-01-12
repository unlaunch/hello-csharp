using System;
using System.Threading;
using io.unlaunch;

namespace hello_csharp
{
    class Program
    {
        private static readonly string SdkKey = "sdkKey";
        private static readonly string FlagKey = "flagKey";

        static void Main(string[] args)
        {
            VerifySdkKeyAndFlagKey();

            var client = UnlaunchClient.Create(SdkKey);

            try
            {
                client.AwaitUntilReady(3000);
                Console.WriteLine("Client is ready!!!");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine($"Client wasn't ready, error: {e.Message}");
            }

            var feature = client.GetFeature(FlagKey, "user-id-123", null);
            Console.WriteLine($"Variation served: {feature.GetVariation()}");
            Console.WriteLine($"EvaluationReason: {feature.GetEvaluationReason()}");
            
            Thread.Sleep(5000);

            client.Shutdown();
        }

        static void VerifySdkKeyAndFlagKey()
        {
            if (string.IsNullOrEmpty(SdkKey))
            {
                Console.WriteLine("Sdk key is null or empty. System exits");
                Environment.Exit(1);
            }

            if (string.IsNullOrEmpty(FlagKey))
            {
                Console.WriteLine("Flag key is null or empty. System exits");
                Environment.Exit(1);
            }
        }
    }
}