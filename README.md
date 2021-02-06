# hello-csharp

> Hello Unlaunch, from CSharp!
 
This is a **demo** project showing how to integrate the [Unlaunch CSharp SDK](https://github.com/unlaunch/hello-csharp) in C# applications. For more details, read our [Getting Started](https://docs.unlaunch.io/docs/getting-started) tutorial.

Unlaunch is a free feature flag service. Please visit [https://www.unlaunch.io](https://www.unlaunch.io) to sign up for a new account today!

# Build Procedure
1. Download code. Edit Program.cs class set your Unlaunch SDK_KEY and FEATURE_FLAG_KEY you want to evaluate as: 

```
private const string SdkKey = "your-sdk-key";
private const string FeatureFlagKey = "your-flag-key";
```

By default, we have set these values to an example feature flag. So you can run the code as is.

When you run the project, it will print something like:

```
[DEMO] Feature returned variation: on. Evaluation reason: Default Rule served.
```
