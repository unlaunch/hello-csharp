using System;
using System.Threading;
using io.unlaunch;

namespace hello_csharp
{
    class Program
    {
        // EDIT ME! Set your-sdk-key to your Unlaunch SDK key.
        private const string SdkKey = "prod-client-42537b5d-6b0a-435f-a134-734ff61f21e9";
        // EDIT ME!  Set your-flag-key to your feature flag key to evaluate
        private const string FeatureFlagKey = "initech-login-form-color";

        static void Main(string[] args)
        {
            VerifySdkKeyAndFlagKey();

            var client = UnlaunchClient.Create(SdkKey);

            try
            {
                client.AwaitUntilReady(TimeSpan.FromSeconds(3));
                Console.WriteLine("Client is ready!!!");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine($"Client wasn't ready, error: {e.Message}");
            }

            // Get variation
            var variation = client.GetVariation(FeatureFlagKey, "user-id-123");

            Console.WriteLine($"[DEMO] getVariation() returned {variation}");
            if (variation == "control")
            {
                Console.WriteLine("'[DEMO] control' variation indicates that Unlaunch Client didn't connect with the server of the flag wasn't found.");
            }

            // Now get Feature with evaluation reason. This is an alternate way to obtain feature flag besides
            // GetVariation() method. This returns additional information such as evaluation reason, and configuration.
            var feature = client.GetFeature(FeatureFlagKey, "user-id-123");
            Console.WriteLine($"[DEMO] Feature returned variation: {feature.GetVariation()}. Evaluation reason: {feature.GetEvaluationReason()}");
            
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

            if (string.IsNullOrEmpty(FeatureFlagKey))
            {
                Console.WriteLine("Flag key is null or empty. System exits");
                Environment.Exit(1);
            }
        }
    }
}