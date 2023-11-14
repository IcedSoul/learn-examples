// Set up the .NET WebAssembly runtime
import { dotnet } from './dotnet.js'

// Get exported methods from the .NET assembly
const { getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .create();

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

// Access JSExport methods using exports.<Namespace>.<Type>.<Method>
document.getElementById("btn").onclick = () => {
    console.log("button clicked");
    document.getElementById("out").innerHTML = "running...";
    const result = exports.Sample.Test();
// Display the result of the .NET method
    document.getElementById("out").innerHTML = `${result}`;
}