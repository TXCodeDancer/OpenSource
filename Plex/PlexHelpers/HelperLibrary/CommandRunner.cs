using System.Text;

namespace HelperLibrary;

public class CommandRunner
{
    public static string RunCommandSync(string filename, string? arguments = null)
    {
        var process = new System.Diagnostics.Process();

        process.StartInfo.FileName = filename;
        if (!string.IsNullOrEmpty(arguments))
        {
            process.StartInfo.Arguments = arguments;
        }

        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        process.StartInfo.UseShellExecute = false;

        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardOutput = true;
        var stdOutput = new StringBuilder();
        process.OutputDataReceived += (sender, args) => stdOutput.AppendLine(args.Data); // Use AppendLine rather than Append since args.Data is one line of output, not including the newline character.

        string? stdError = null;
        try
        {
            process.Start();
            process.BeginOutputReadLine();
            stdError = process.StandardError.ReadToEnd();
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new Exception("OS error while executing " + Format(filename, arguments) + ": " + e.Message, e);
        }

        if (process.ExitCode == 0)
        {
            return stdOutput.ToString();
        }
        else
        {
            var message = new StringBuilder();

            if (!string.IsNullOrEmpty(stdError))
            {
                message.AppendLine(stdError);
            }

            if (stdOutput.Length != 0)
            {
                message.AppendLine("Std output:");
                message.AppendLine(stdOutput.ToString());
            }

            throw new Exception(Format(filename, arguments) + " finished with exit code = " + process.ExitCode + ": " + message);
        }
    }

    public static async Task<string> RunCommandAsync(string filename, string? arguments = null)
    {
        var process = new System.Diagnostics.Process();

        process.StartInfo.FileName = filename;
        if (!string.IsNullOrEmpty(arguments))
        {
            process.StartInfo.Arguments = arguments;
        }

        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        process.StartInfo.UseShellExecute = false;

        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardOutput = true;
        var stdOutput = new StringBuilder();
        process.OutputDataReceived += (sender, args) => stdOutput.AppendLine(args.Data); // Use AppendLine rather than Append since args.Data is one line of output, not including the newline character.

        string? stdError = null;
        try
        {
            process.Start();
            process.BeginOutputReadLine();
            stdError = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();
        }
        catch (Exception e)
        {
            throw new Exception("OS error while executing " + Format(filename, arguments) + ": " + e.Message, e);
        }

        if (process.ExitCode == 0)
        {
            return stdOutput.ToString();
        }
        else
        {
            var message = new StringBuilder();

            if (!string.IsNullOrEmpty(stdError))
            {
                message.AppendLine(stdError);
            }

            if (stdOutput.Length != 0)
            {
                message.AppendLine("Std output:");
                message.AppendLine(stdOutput.ToString());
            }

            throw new Exception(Format(filename, arguments) + " finished with exit code = " + process.ExitCode + ": " + message);
        }
    }

    private static string Format(string filename, string? arguments)
    {
        return "'" + filename +
            ((string.IsNullOrEmpty(arguments)) ? string.Empty : " " + arguments) +
            "'";
    }
}

///// <summary>
///// An Async wrapper for <see cref="Process"/>.
///// </summary>
//public class ProcessAsync
//{
//    private string _fileName;
//    private string _arguments;

//    public ProcessAsync(string fileName, string arguments)
//    {
//        _fileName = fileName;
//        _arguments = arguments;
//    }

//    public async Task<string> Run(StringBuilder stdin = null)
//    {
//        // Initialize
//        var cmd = new System.Diagnostics.Process();
//        cmd.StartInfo.FileName = _fileName;
//        cmd.StartInfo.RedirectStandardInput = true;
//        cmd.StartInfo.RedirectStandardOutput = true;
//        cmd.StartInfo.CreateNoWindow = true;
//        cmd.StartInfo.UseShellExecute = false;
//        cmd.StartInfo.Arguments = _arguments;

//        // Create a task that waits for the Process to finish
//        var cmdExited = new CmdExitedTaskWrapper();
//        cmd.EnableRaisingEvents = true;
//        cmd.Exited += cmdExited.EventHandler;

//        // Start process
//        cmd.Start();

//        // Pass any stdin if necessary
//        if (stdin != null)
//        {
//            await cmd.StandardInput.WriteAsync(stdin);
//            await cmd.StandardInput.FlushAsync();
//            cmd.StandardInput.Close();
//        }

//        // Wait for process to end and return stdout
//        await cmdExited.Task;
//        return cmd.StandardOutput.ReadToEnd();

//    }

//    /// <remarks>
//    /// We can't wait on a Process directly, so create a wrapper for a
//    /// task that waits for the <see cref="Process.Exited"/> Event to be
//    /// raised.
//    /// </remarks>
//    private class CmdExitedTaskWrapper
//    {
//        private TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

//        public void EventHandler(object sender, EventArgs e)
//        {
//            _tcs.SetResult(true);
//        }

//        public Task Task => _tcs.Task;

//    }

//}

//Usage
//var p = new ProcessAsync("pandoc", $"\"{filePath}\" -s -o \"{outFile}\"");
//Console.WriteLine(await p.Run());
