using CommandLine;

await Parser.Default.ParseArguments<Options>(Environment.GetCommandLineArgs()).WithParsedAsync(async (x) => await UpdateDNSRecords(x));


//https://github.com/frodehus/azure-dyndns