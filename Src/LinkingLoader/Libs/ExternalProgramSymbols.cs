using Common.ArithmeticOps;

namespace LinkingLoader.Libs;

public class ExternalProgramSymbols
{
    public string ControlSectionName { get; set; }
    public string EndAddress { get; set; }
    public string StartAddress { get; set; }
    public string Length { get; set; }
    public Dictionary<string, string> Symbols { get; set; } = new();
    public ExternalProgramSymbols(string[] hte, string startAddress)
    {
        StartAddress = startAddress;

        ControlSectionName = hte[0].Substring(2, 8).Replace("X", "");

        Length = hte[0].Substring(hte[0].Length - 6).Replace("0", "");

        EndAddress = HexOperations.Addition(StartAddress, Length);

        // get each variable name and location
        string refinedD = hte[1].Substring(2).Replace(".", "");
        for (int i = 0; i < refinedD.Length / 6; i++)
        {
            // get each 6 characters
            string varData = refinedD.Substring(6 * 1, 6 * (i + 1));

            // divide them by two, store the first one as key and the second one as value 
            Symbols.Add(varData.Substring(6).Replace("X", ""), varData.Substring(6, 12).Replace("0", ""));
        }
    }
}