﻿using Common.Utils;
using Common.Libs;
using LinkingLoader.Libs;
using LinkingLoader.Utils;
using LinkingLoader.ValueObjects;

internal class Program
{
    private static void Main(string[] args)
    {
        // Read HTE's and starting location counter
        bool isEnterMore = true;
        int i = 1;
        LinkedList<string[]> htes = new();
        while (isEnterMore)
        {
            htes.AddLast(CodeFormatter.SplitLines(ReadWrite.ReadProgramCode($"Enter Program {i} HTE (Press Enter twice to finish):")));
            if (i == 3)
            {
                string response = ReadWrite.ReadLine("Do you want to import more programs? (response with y/n)");
                if (response == "n")
                {
                    isEnterMore = false;
                }
            }
            i++;
        }
        string startAddress = ReadWrite.ReadLine("Enter starting Location Counter:");
        Coordinates startAddressCoordinates = new(
            startAddress.Substring(0, 3),
            startAddress.Substring(3)
        );

        // external symbols
        LinkedList<ExternalProgramSymbols> externalSymbols = new();
        int j = 0;
        foreach (string[] programHte in htes)
        {
            externalSymbols.AddLast(
                new ExternalProgramSymbols(
                    programHte,
                    j == 0 ? startAddressCoordinates : externalSymbols.ElementAt(j - 1).EndAddress));
            j++;
        }

        // main table variable
        MainTable mainTable = new(htes, externalSymbols);

        // formatted print
        Write.FormattedPrint(); // external symbol table
        Write.FormattedPrint(); // main table
    }
}